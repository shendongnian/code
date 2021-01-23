    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace IndexOfAny
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("University of California, 1980-85".IndexOfAny("0123456789".ToCharArray()));
            }
        }
    }
