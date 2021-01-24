    class Program
    { 
        static void Main(string[] args) //This is a Method, named "Main". It's called when the program starts
        {
            double numberOne;
            double numberTwo;
            string method;
            Console.WriteLine("What would you like to do? <+, -, *, />");
            method = Console.ReadLine();
            Console.Write("Please type the first number: ");
            numberOne = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please type the second number: ");
            numberTwo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(numberOne + method + numberTwo + " = " + Calculate(numberOne,numberTwo,method));
            Console.ReadKey();
        }
        static double Calculate(double input1, double input2, string operator)
        {
            switch(operator)
            {
                case "+": return input1 + input2;
                case "-": return input1 - input2;
                case "*": return input1 * input2;
                case "/": return input1 / input2;
                default: throw new InvalidOperatorinException($"Unknown operator: {operator}");
            }
        }
    }
