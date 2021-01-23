    class Program
    {
        static void Main()
        {
            using (var client = new TcpClient("127.0.0.1", 10100))
            using (var stream = client.GetStream())
            using (var writer = new BinaryWriter(stream))
            {
                var message = "<some test xml file>";
                var buffer = Encoding.UTF8.GetBytes(message);
                // Send the total message length in the first 4 bytes
                // so that the server knows how much it has to read
                writer.Write(buffer.Length);
                writer.Write(buffer);
                Console.WriteLine("Successfully sent {0} bytes to server", buffer.Length);
            }
        }
    }
