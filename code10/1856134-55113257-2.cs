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
