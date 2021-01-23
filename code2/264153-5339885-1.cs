    static void Main(string[] args)
    {
        TcpListener listener = new TcpListener(IPAddress.Any , 8000);
        TcpClient client;
        listener.Start();
        while (true) // Add your exit flag here
        {
            client = listener.AcceptTcpClient();
            ThreadPool.QueueUserWorkItem(ThreadProc, client);
        }
    }
    private static void ThreadProc(object obj)
    {
        var client = (TcpClient)obj;
        // Do your work here
    }
