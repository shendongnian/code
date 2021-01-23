    class Program
    {
        static void Main()
        {
            var listener = new TcpListener(new IPEndPoint(IPAddress.Loopback, 10100));
            listener.Start();
            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                using (var stream = client.GetStream())
                using (var reader = new BinaryReader(stream))
                {
                    // The first 4 bytes of the message will indicate
                    // the total message length
                    var length = reader.ReadInt32();
                    var buffer = reader.ReadBytes(length);
                    Console.WriteLine("Received {0} bytes from client:", length);
                    Console.WriteLine("{0}", Encoding.UTF8.GetString(buffer));
                }
            }
        }
    }
