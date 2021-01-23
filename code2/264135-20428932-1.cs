        using System;
    
        public static class Program
        {
            [STAThreadAttribute]
            public static void Main()
            {
                Console.WriteLine("What now?");
                Console.ReadKey(true);
    
                App.Main();
            }
        }
