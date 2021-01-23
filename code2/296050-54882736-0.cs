    using System;
    
    namespace ConsoleApplication1
    {
        class Test
        {
    
            public static void Main(String[] args)
            {
                bool check;
                string testStr = "ABC";
                string testNum = "123";
                check = CheckNumeric(testStr);
                Console.WriteLine(check);
                check = CheckNumeric(testNum);
                Console.WriteLine(check);
                Console.ReadKey();
    
            }
    
            public static bool CheckNumeric(string input)
            {
                int outPut;
                if (int.TryParse(input, out outPut))
                    return true;
    
                else
                    return false;
            }
    
        }
    }
