    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server started");
            string word = "";
            savedObject saved = new savedObject();
            while (true)
            {
                TcpClient connection = server.AcceptTcpClient();
                Console.WriteLine("connection accepted");
                ThreadPool.QueueUserWorkItem(saved.ProssecClient, connection);
            }
        }
    }
