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
                double num1 = Convert.ToDouble(Console.ReadLine());
    
                string op = Console.ReadLine();
    
                if (op == "+" || op == "-" || op == "/" || op == "*")
                {
                    Calc(num1, op);
                }
                else
                {
                    Console.WriteLine("Invalid Operator");
                }
    
                Console.WriteLine(Ans);
    
                Console.ReadLine();
            }
    
            static double Calc(double num1, string op)
            {
                Console.Write("Enter Second Number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());
    
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
