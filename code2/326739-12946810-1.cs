    class Program
    {
        static void Main(string[] args)
        {
            // ZMQ Context and client socket
            using (Context context = new Context(1))
            using (Socket requester = context.Socket(SocketType.REQ))
            {
                requester.Connect("tcp://localhost:5555");
                string request = "Hello";
                for (int requestNum = 0; requestNum < 10; requestNum++)
                {
                    Console.WriteLine("Sending request {0}...", requestNum);
                    requester.Send(request, Encoding.Unicode);
                    string reply = requester.Recv(Encoding.Unicode);
                    Console.WriteLine("Received reply {0}: {1}", requestNum, reply);
                }
            }
        }
    }
}
