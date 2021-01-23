    using System;
    
    namespace TestParams
    {
        class Program
        {
            static void TestParamsStrings(params string[] strings)
            {
                if(strings == null)
                {
                    Console.WriteLine("strings is null.");
                }
                else
                {
                    Console.WriteLine("strings is not null.");
                }
            }
    
            static void TestParamsInts(params int[] ints)
            {
                if (ints == null)
                {
                    Console.WriteLine("ints is null.");
                }
                else
                {
                    Console.WriteLine("ints is not null.");
                } 
            }
    
            static void Main(string[] args)
            {
                string[] stringArray = null;
    
                TestParamsStrings(stringArray);
                TestParamsStrings();
                TestParamsStrings(null);
                TestParamsStrings(null, null);
    
                Console.WriteLine("-------");
    
                int[] intArray = null;
    
                TestParamsInts(intArray);
                TestParamsInts();
                TestParamsInts(null);
                //TestParamsInts(null, null); -- Does not compile.
            }
        }
    }
