    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(Foo));
            thread.Start();
            Console.ReadKey();
            thread.Abort(); // cause ThreadAbortException to be thrown    
            Console.ReadKey();
        }
        static void Foo()
        {
            try
            {
                while( true )
                {
                    Console.WriteLine("Long running process...");
                    Thread.Sleep(100000);
                }
            }
            catch( ThreadAbortException ex )
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("Thread Closing ...");
            }
        }
    }
