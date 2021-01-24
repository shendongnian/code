    static void Main(string[] args)
    {
        var serverThread = new Thread(() =>
        {
            var server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            var client = server.AcceptTcpClient();
            var ssl = new SslStream(client.GetStream());
            // certificate file with private key and password
            var cert = new X509Certificate2(@"rsa-4096.pfx", "hh87$-Jqo");
            ssl.AuthenticateAsServer(cert);
            ssl.Write(Encoding.ASCII.GetBytes("Hello world"), 0, 11);
            ssl.Flush();
            ssl.Close();
            server.Stop();
        });
        var clientThread = new Thread(() =>
        {
            var client = new TcpClient();
            client.Connect(IPAddress.Loopback, 12345);
            // last parameter disables certificate validation
            var ssl = new SslStream(client.GetStream(), false, (a, b, c, d) => true);
            ssl.AuthenticateAsClient("localhost");
            using (var sr = new StreamReader(ssl, Encoding.ASCII))
            {
                string recivedText = sr.ReadToEnd();
                Console.WriteLine(recivedText);
            }
        });
        serverThread.Start();
        clientThread.Start();
        serverThread.Join();
        clientThread.Join();
    }
