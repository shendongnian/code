     class Program
        {
            static void Main(string[] args)
            {
                string a = string.Empty;
                do
                {
                    Console.WriteLine("Please input two numbers");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    int num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please choose the following you want to do");
                    Console.WriteLine("1. Add");
                    Console.WriteLine("2. Minus");
                    Console.WriteLine("3. Mult");
                    Console.WriteLine("4. Div");
                    int number = Convert.ToInt32(Console.ReadLine());
                    switch (number)
                    {
                        case 1:
                            Console.WriteLine("Your result is" + Add(num1, num2));
                            break;
                        case 2:
                            Console.WriteLine("Your result is" + Minus(num1, num2));
                            break;
                        case 3:
                            Console.WriteLine("Your result is" + Mult(num1, num2));
                            break;
                        case 4:
                            Console.WriteLine("Your result is" + Div(num1, num2));
                            break;
                        default:
                            Console.WriteLine("Please input again");
                            break;
                    }
                    a = Console.ReadLine();
                }
                while (a == "y");
            }
    
            public static int Add(int num1, int num2)
            {
                return num1 + num2;
            }
            public static int Minus(int num1, int num2)
            {
                return num1 - num2;
            }
            public static int Mult(int num1, int num2)
            {
                return num1 * num2;
            }
            public static double Div(int num1, int num2)
            {
                return num1 / num2;
            }
        }
