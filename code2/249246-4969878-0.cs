    public class TestTryFinally
        {
            public static void Main()
            {
                int i = 123;
                string s = "Some string";
                object o = s;
    
                try
                {
                    // Invalid conversion; o contains a string not an int
                    i = (int)o;
                }
    
                finally
                {
                    Console.Write("i = {0}", i);
                    Console.Write("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
