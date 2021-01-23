    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace test
    {
        class Program
        {
            enum e
            {
                t1,
                t2
            }
            static void Main(string[] args)
            {
                foreach (var v in Enum.GetNames(typeof(e))) 
                {
    
                }
            }
        }
    }
