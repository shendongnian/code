    namespace Example
    {
        using System;
    
        public delegate double Operation(double first, double second);
    
        public static class Operations
        {
            public static readonly Operation Sum = (first, second) => first + second;
            public static readonly Operation Subtract = (first, second) => first - second;
            public static readonly Operation Multiply = (first, second) => first * second;
            public static readonly Operation Divide = (first, second) => first / second;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                double seed = 0;
                double aggregateValue = 0;
    
                aggregateValue = PerformOperation(Operations.Sum, 5, 10);
                Console.WriteLine(aggregateValue);
    
                aggregateValue = PerformOperation(Operations.Multiply, aggregateValue, 10);
                Console.WriteLine(aggregateValue);
    
                aggregateValue = PerformOperation(Operations.Subtract, aggregateValue, 10);
                Console.WriteLine(aggregateValue);
    
                aggregateValue = PerformOperation(Operations.Divide, aggregateValue, 10);
                Console.WriteLine(aggregateValue);
    
                // You can even pass delegates to other methods with matching signatures,
                // here to get the power of ten.
                aggregateValue = PerformOperation(Math.Pow, aggregateValue, 10);
                Console.WriteLine(aggregateValue);
    
                Console.ReadLine();
            }
    
            private static double PerformOperation(Operation operation, double aggregateValue, double sourceValue)
            {
                return operation(aggregateValue, sourceValue);
            }
        }
    }
