    using System;
    using System.Data;
    
    namespace EvaluateMathString_333737
    {
        class Program
        {
            static void Main(string[] args)
            {
                string thestring = "3*8+5";
                Console.WriteLine(new DataTable().Compute(thestring, null));
                Console.ReadLine();
            }
        }
    }
