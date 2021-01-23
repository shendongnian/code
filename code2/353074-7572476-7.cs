    public class Program
    {
        public static ExternalResourceHandler _erh = new ExternalResourceHandler();
        
        static int Main()
        {   
            Thread erhThread = new Thread(()=>{_erh.Run();});
            erhThread.IsBackground = true;
            erhThread.Start();
            Console.WriteLine("Type 'exit' to stop or press enter to enqueue another request.");
            string input = Console.ReadLine();
            while(input != "exit")
            {
                _erh.EnqeueRequest(new Request());
                input = Console.ReadLine();
            }
            
            // Stops the erh by setting the running flag to false
            _erh.Stop();
            // You may also need to interrupt the thread in order to
            // get it out of a blocking state prior to calling Join()
            erhThread.Join();
            return 0;
        }
    }
