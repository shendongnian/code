    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace test
    {
        class Program
        {
            enum OperationEnum { Sum, Muiltiply, Divide, Subtract }
            static Dictionary<OperationEnum, Func<double, double, double>> actions = new Dictionary<OperationEnum, Func<double, double, double>>()
            {
                { OperationEnum.Sum, (a,b) => a+b },
                { OperationEnum.Muiltiply, (a,b) => a*b },
                { OperationEnum.Divide, (a,b) => a/b },
                { OperationEnum.Subtract, (a,b) => a-b },
            };
            static void Main(string[] args)
            {
                Console.WriteLine(string.Format("{0}", Evaluate(OperationEnum.Sum, 1, 3)));
            }
            static double Evaluate(OperationEnum operation, double a, double b)
            {
                return actions[operation](a, b);
            }
        }
    }
