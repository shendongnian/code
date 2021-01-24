    static void Main(string[] args)
            {
                Program program = new Program();
                int a = 3;
                int result = program.Test(ref a);
                Console.WriteLine(result); // result = 0
                Console.ReadKey();
            }
    
            private int Test(ref int a)
            {
                a--;
                if (a != 0)
                {
                    Test(ref a);
                }
                return a;
            }
