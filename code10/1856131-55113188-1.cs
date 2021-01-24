    namespace NewNew
    {
        class Program
        {
            private static double Ans;
            private static double num1;
            private static double num2;
            private static string op;
    
            static void Main(string[] args)
            {
                Console.Write("Enter First Number: ");
                num1 = Convert.ToDouble(Console.ReadLine());
    
                op = Console.ReadLine();
    
                if (op == "+" || op == "-" || op == "/" || op == "*")
                {
                    Calc();
                }
                else
                {
                    Console.WriteLine("Invalid Operator");
                }
    
                Console.WriteLine(Ans);
                Console.ReadLine();
            }
    
            static double Calc()
            {
                Console.Write("Enter Second Number: ");
                num2 = Convert.ToDouble(Console.ReadLine());
    
                if (op == "+")
                {
                    Ans = num1 + num2;
                }
                else if (op == "-")
                {
                    Ans = num1 - num2;
                }
                else if (op == "/")
                {
                    Ans = num1 / num2;
                }
                else if (op == "*")
                {
                    Ans = num1 * num2;
                }
                return Ans;
            }
        }
    }
