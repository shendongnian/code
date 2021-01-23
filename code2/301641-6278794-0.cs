    class Program
    {
        static void Main(string[] args)
        {
            const string server = "smtp.live.com";
            const int port = 587;
            using (var client = new TcpClient(server, port))
            {
                using (var stream = client.GetStream())
                using (var clearTextReader = new StreamReader(stream))
                using (var clearTextWriter = new StreamWriter(stream) { AutoFlush = true })
                using (var sslStream = new SslStream(stream))
                {
                    var connectResponse = clearTextReader.ReadLine();
                    if (!connectResponse.StartsWith("220"))
                        throw new InvalidOperationException("SMTP Server did not respond to connection request");
                    clearTextWriter.WriteLine("HELO");
                    var helloResponse = clearTextReader.ReadLine();
                    if (!helloResponse.StartsWith("250"))
                        throw new InvalidOperationException("SMTP Server did not respond to HELO request");
                    clearTextWriter.WriteLine("STARTTLS");
                    var startTlsResponse = clearTextReader.ReadLine();
                    if (!startTlsResponse.StartsWith("220"))
                        throw new InvalidOperationException("SMTP Server did not respond to STARTTLS request");
                    sslStream.AuthenticateAsClient(server);
                    using (var reader = new StreamReader(sslStream))
                    using (var writer = new StreamWriter(sslStream) { AutoFlush = true })
                    {
                        writer.WriteLine("EHLO " + server);
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
