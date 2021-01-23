    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace test
    {
        class Program
        {
            enum OperationEnum : int { Sum, Muiltiply, Divide, Subtract }
            static List<Func<double, double, double>> actions = new List<Func<double, double, double>>()
            {
                { (a,b) => a+b },
                { (a,b) => a*b },
                { (a,b) => a/b },
                { (a,b) => a-b },
            };
            static void Main(string[] args)
            {
                Console.WriteLine(string.Format("{0}", actions[(int)OperationEnum.Sum](1, 3));
            }
        }
    }
