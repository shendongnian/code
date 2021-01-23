    class Myclass
        {
            // will print 1st also sets up Event Handler
            static Myclass()
            {
                Console.WriteLine("1st");
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            }
            static void Main(string[] args)
            {
                Console.WriteLine("2nd"); // it will print 2nd
            }
    
            static void CurrentDomain_ProcessExit(object sender, EventArgs e)
            {
                Console.WriteLine("3rd");
            }
        }
