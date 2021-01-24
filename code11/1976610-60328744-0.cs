using System;
namespace figurearea
{
    class Program
    {
        static void Main()
        {
            string choice = "";
            Console.WriteLine("[1]Area of circle");
            Console.WriteLine("[2]Area of rectangle");
            Console.WriteLine("[3]Area of cylander");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                CirArea();
                Another();
            }
            else if (choice == "2")
            {
                TriArea();
                Another();
            }
            else if (choice == "3")
                CylArea();
            Another();
        }
        private static void CirArea()
        {
            double cirarea;
            double radius;
            double pi = 3.14;
            Console.WriteLine("Please enter the radius of the circle :");
            radius = double.Parse(Console.ReadLine());
            cirarea = pi * Math.Sqrt(radius);
            Console.WriteLine("The area of the circle is :"+ cirarea);
        }
        private static void TriArea()
        {
            double triarea;
            double length;
            double width;
            Console.WriteLine("Please enter the length of the rectangle: ");
            length = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the width of the rectangle: ");
            width = double.Parse(Console.ReadLine());
            triarea = length * width;
            Console.WriteLine("The area of the rectangle is :" + triarea);
        }
        private static void CylArea()
        {
            double cylarea;
            double radius;
            double height;
            double pi = 3.14;
            Console.WriteLine("Please enter the radius of cylinder: ");
            radius = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the height of the cylinder: ");
            height = double.Parse(Console.ReadLine());
            cylarea = 2 * pi * radius * height + 2 * pi * Math.Sqrt(radius);
            Console.WriteLine("The area of the cylinder is :"+ cylarea);
        }
        private static void Another()
        {
            string answer;
            Console.WriteLine("Do you want to get another calculation?[Y/N]");
            answer = Console.ReadLine();
            if (answer.Equals("Y",StringComparison.CurrentCultureIgnoreCase))
            {
                int choice = 0;
                Console.WriteLine("[1]Area of circle");
                Console.WriteLine("[2]Area of rectangle");
                Console.WriteLine("[3]Area of cylander");
                choice = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("You can now close this program.");
            }
        }
    }
}
