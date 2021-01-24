        private static double _answer;
        private static double _firstNumber;
        private static double _secondNumber;
        private static string _operation;
        static void Main(string[] args)
        {
            Console.Write("Enter First Number: ");
            _firstNumber = Convert.ToDouble(Console.ReadLine());
            _operation = Console.ReadLine();
            if (_operation == "+" || _operation == "-" || _operation == "/" || _operation == "*")
            {
                Calc();
            }
            else
            {
                Console.WriteLine("Invalid Operator");
            }
            Console.WriteLine(_answer);
            Console.ReadLine();
        }
        static double Calc()
        {
            Console.Write("Enter Second Number: ");
            double secondNumber = Convert.ToDouble(Console.ReadLine());
            if (_operation == "+")
            {
                _answer = _firstNumber + secondNumber;
            }
            else if (_operation == "-")
            {
                _answer = _firstNumber - secondNumber;
            }
            else if (_operation == "/")
            {
                _answer = _firstNumber / secondNumber;
            }
            else if (_operation == "*")
            {
                _answer = _firstNumber * secondNumber;
            }
            return _answer;
        }
