    public class Program
    {
        public static ExternalResourceHandler _erh = new ExternalResourceHandler();
        
        static int Main()
        {   
            Console.WriteLine("Type 'exit' to stop or press enter to enqueue another request.");
            string input = Console.ReadLine();
            while(input != "exit")
            {
                _erh.EnqeueRequest(new Request());
                input = Console.ReadLine();
            }
            
            return 0;
        }
    }
