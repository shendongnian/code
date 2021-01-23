    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace BadFloat
    {
        class Program
        {
            static void Main(string[] args)
            {
                float yourMoneyAccumulator = 0.0f;
                int count = 20000;
                float increment = 0.01f; //1 cent
                for (int i = 0; i < count; i++)
                    yourMoneyAccumulator += increment;
                Console.WriteLine(yourMoneyAccumulator + " accumulated vs. " + increment * count + " expected");
            }
        }
    }
