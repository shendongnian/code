    static void Main(string[] args)
        {          
            TimeSpan t = TimeSpan.FromMilliseconds(System.Environment.TickCount);
            Console.WriteLine( DateTime.Now.Subtract(t));          
        }
