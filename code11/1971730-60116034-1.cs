    class Program
    {
        //add public for the error: inconsist accessibility bla bla..
        public enum MathOperator { Add, Subtract, Multiply, Divide, }; 
    
        static void Main(string[] args)
        {
            Console.WriteLine(Test5(10, 10, MathOperator.Add));
        }
            
        public static double Test5(double num1, double num2, MathOperator op)
        {
            double num3;
                
            switch (op)
            {
                case MathOperator.Add:
                    num3 = num1 + num2;
                    return num3;
                case MathOperator.Subtract:
                    num3 = num1 - num2;
                    return num3;
                case MathOperator.Multiply:
                    num3 = num1 * num2;
                    return num3;
                case MathOperator.Divide:
                    num3 = num1 / num2;
                    return num3;
               //add default switch case for error: not all code paths return a value  bla bla..
                default:
                    return 0;
            };
    
        }
    }
