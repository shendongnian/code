    class Program
    {
        const int LISTENING_PORT = 10001;
        const string IMAGE_DIR = @"C:\Users\joehoper\Desktop\imgservtest\server\";
        const int BUFFER_SIZE = 10240;
        static void Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Any, LISTENING_PORT);
            listener.Start();
            Console.WriteLine($"Listening on port {LISTENING_PORT}...");
            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"Accepted client {client.Client.RemoteEndPoint}");
                ThreadPool.QueueUserWorkItem(cb => ClientThread(client));
            }
        }
        static void ClientThread(TcpClient client)
        {
            try
            {
                using (var stream = client.GetStream())
                {
                    // Read filename length
                    int fNameLen = stream.ReadByte();
                    byte[] fNameBytes = new byte[fNameLen];
                    // Read filename
                    stream.Read(fNameBytes, 0, fNameLen);
                    string fName = Encoding.Unicode.GetString(fNameBytes);
                    using (var fs = File.OpenWrite(IMAGE_DIR + fName))
                    {
                        byte[] buffer = new byte[BUFFER_SIZE];
                        while (true)
                        {
                            int r = stream.Read(buffer, 0, BUFFER_SIZE);
                            if (r == 0)
                                break;
                            fs.Write(buffer, 0, r);
                        }
                    }
                }
            }
            finally
            {
                client.Close();
            }
        }
    }
