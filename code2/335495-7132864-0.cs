    class Program
    {
        static void Main()
        {
            using (var client = new TcpClient("www.google.com", 80))
            {
                using (var stream = client.GetStream())
                using (var writer = new StreamWriter(stream))
                using (var reader = new StreamReader(stream))
                {
                    writer.AutoFlush = true;
                    // Send request headers
                    writer.WriteLine("GET / HTTP/1.1");
                    writer.WriteLine("Host: www.google.com:80");
                    writer.WriteLine("User-Agent: Pastebin API 0.1");
                    writer.WriteLine("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                    writer.WriteLine("Accept-Charset: ISO-8859-1,UTF-8;q=0.7,*;q=0.7");
                    writer.WriteLine("Cache-Control: no-cache");
                    writer.WriteLine("Accept-Language: en;q=0.7,en-us;q=0.3");
                    writer.WriteLine("Connection: close");
                    writer.WriteLine();
                    writer.WriteLine();
    
                    // Read the response from server
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
