using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UserInteraction();

            Console.ReadKey();
        }
        public static void UserInteraction()
        {

            string option = MainLoop();
            while (option != "5")
            {
                switch (option)
                {
                    case "1":
                        GetTriangle();
                        break;
                    case "2":
                        Console.WriteLine("Podaj a");
                        double d = GetDouble();
                        Console.WriteLine("Podaj b");
                        double e = GetDouble();
                        ShowFigure(new Rectangle(d, e));
                        break;
                    case "3":
                        Console.WriteLine("Podaj r");
                        double r = GetDouble();
                        ShowFigure(new Circle(r));
                        break;
                    case "4":
                        FillAndShowFigureArrray(10);
                        break;
                    case "5":
                        break;

                }
                option= MainLoop();
            }
        }
        private static void GetTriangle()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Podaj a");
                double a = GetDouble();
                Console.WriteLine("Podaj b");
                double b = GetDouble();
                Console.WriteLine("Podaj c");
                double c = GetDouble();
                if (!(a >= b + c || b >= c + a || c >= a + b))
                {
                    loop = false;
                    ShowFigure(new Triangle(a, b, c));
                }
                else
                    Console.WriteLine("To nie są boki trójkąta. Jeden bok jest wiekszy lub równy dwóm pozostałym");

            }
        }

        private static double GetDouble()
        {
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            else 
            {
                Console.WriteLine("To nie jest liczba");
                GetDouble();
                return 0;
            }
            
        }
        private static string MainLoop()
        {
            bool correct = false;
            string option = "4";
            while (!correct)
            {
                Console.WriteLine("Wybierz opcje: ");
                Console.WriteLine("1 - Oblicz pole i obwód trójkąta");
                Console.WriteLine("2 - Oblicz pole i obwód prostokata");
                Console.WriteLine("3 - Oblicz pole i obwód koła");
                Console.WriteLine("4 - Wylosuj 10 figur");
                Console.WriteLine("5 - Wyjdź");

                option = Console.ReadLine();

                if (option == "1" || option == "2" || option == "3" || option == "4"||option=="5")
                {
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Nie ma takiej opcji");
                }
                
            }
            return option;
        }

        public static void ShowFigure(Figure figure) 
        {
            double area;
            double perimeter;
            if (figure.GetType() == typeof(Triangle))
            {
                area = figure.CalculateArea();
                perimeter = figure.CalculatePerimeter();   
                Console.WriteLine("Pole tego trójkąta wynosi " + area + "a jego obwód " + perimeter );
            }
            else if(figure.GetType() == typeof(Rectangle))
            {
                area = figure.CalculateArea();
                perimeter = figure.CalculatePerimeter();
                Console.WriteLine("Pole tego prostokąta wynosi " + area + "a jego obwód " + perimeter);
            }
            else if(figure.GetType() == typeof(Circle))
            {
                area = figure.CalculateArea();
                perimeter = figure.CalculatePerimeter();
                Console.WriteLine("Pole tego koła wynosi " + area + "a jego obwód " + perimeter);
            }
        }
      

        public double GetFullArea(List<Figure> list)
        {
            double ToReturn=0;
            foreach (Figure f in list)
            {
                ToReturn += f.CalculateArea();
            }
            return ToReturn;

        }
     
        

        public static void FillAndShowFigureArrray(int size)
        {
            List<Figure> list = new List<Figure>();
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                int choice = rnd.Next(0, 3);

                if (choice == 0)
                {
                    Rectangle rectangle = new Rectangle(rnd.NextDouble() * 10, rnd.NextDouble() * 10);
                    list.Add(rectangle);

                }
                else if (choice == 1)
                {
                    double a = rnd.NextDouble() * 10;
                    double b = rnd.NextDouble() * 10;
                    double c = rnd.NextDouble() * 10;

                    while (a >= b + c || b >= c + a || c >= a + b)
                    {

                        a = rnd.NextDouble() * 10;
                        b = rnd.NextDouble() * 10;
                        c = rnd.NextDouble() * 10;
                    }

                    Triangle triangle = new Triangle(a, b, c);
                    list.Add(triangle);

                }
                else if (choice == 2)
                {
                    Circle circle = new Circle(rnd.NextDouble() * 10);
                    list.Add(circle);

                }
            }
            list.ForEach(f => ShowFigure(f));


        }

     
    }

    class Figure
    {
        protected const double PI = 3.141592;
        public virtual double CalculateArea()
        {
            return 0;
        }
        public virtual double CalculatePerimeter()
        {
            return 0;
        }
    }

    class Rectangle : Figure
    {
        protected double a;
        protected double b;
        public Rectangle(double a,double b)
        {
            this.a = a;
            this.b = b;   
        }

        public override double CalculateArea()
        {
            return a * b;
        }
        public override double CalculatePerimeter()
        {
            return 2 * (a + b);
        }
    }

 

    class Triangle : Figure
    {
        protected double a;
        protected double b;
        protected double c;

        public Triangle(double a, double b,double c)
        {
            this.a = a;
            this.b = b;
            this.c = c; 
        }
        public override double CalculateArea()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override double CalculatePerimeter()
        {
            return a + b + c;
        }

    }
    class Circle : Figure
    {
        double r;
        public Circle (double r)
        {
            this.r = r;
        }
        public override double CalculateArea()
        {
            return PI * r * r;
        }
        public override double CalculatePerimeter()
        {
            return 2 * PI * r;
        }
    }

}
