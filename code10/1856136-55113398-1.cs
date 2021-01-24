        private static double answer;
        private static double firstNumber;
        private static double secondNumber;
        private static string operation;
        static void Main(string[] args)
        {
            Console.Write("Enter First Number: ");
            firstNumber = Convert.ToDouble(Console.ReadLine());
            operation = Console.ReadLine();
            if (operation == "+" || operation == "-" || operation == "/" || operation == "*")
            {
                Calc();
            }
            else
            {
                Console.WriteLine("Invalid Operator");
            }
            Console.WriteLine(answer);
            Console.ReadLine();
        }
        static double Calc()
        {
            Console.Write("Enter Second Number: ");
             secondNumber = Convert.ToDouble(Console.ReadLine());
            if (operation == "+")
            {
                answer = firstNumber + secondNumber;
            }
            else if (operation == "-")
            {
                answer = firstNumber - secondNumber;
            }
            else if (operation == "/")
            {
                answer = firstNumber / secondNumber;
            }
            else if (operation == "*")
            {
                answer = firstNumber * secondNumber;
            }
            return answer;
        }
