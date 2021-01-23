    namespace SO_Console_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                char[] options = { 'a', 'l', 'w' };
                Random rand = new Random(DateTime.Now.Millisecond);
    
                for (int i = 0; i <= 100; i++)
                {
                    Console.WriteLine(OptionPicker(options,rand).ToString());
                }
                Console.ReadLine();
            }
    
             
            public static char OptionPicker(char[] options, Random rand)
            {
                return options[rand.Next(0, options.Length)];
            }
    
        }
    }
