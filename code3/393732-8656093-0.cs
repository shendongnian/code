    class Program
    {
        static void Main()
        {
            var listener = new TcpListener(IPAddress.Loopback, 11000);
            listener.Start();
            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                using (var stream = client.GetStream())
                using (var output = File.Create("result.dat"))
                {
                    Console.WriteLine("Client connected. Starting to receive the file");
                    // read the file in chunks of 1KB
                    var buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }
                }
            }
    
        }
    }
