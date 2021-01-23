    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = new Task<int>(Test);
            task.Start();
            
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex);    
            }
            
            Console.ReadLine();
        }
    
        static int Test()
        {
            throw new Exception();
        }
    }
