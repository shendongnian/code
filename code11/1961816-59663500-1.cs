        static async Task UdpServerClient(string serverName,Pipe p)
        {
            while (true)
            {
                var readResult = await p.Reader.ReadAsync();
                var message = Encoding.ASCII.GetString(readResult.Buffer.FirstSpan.ToArray());
                Console.WriteLine($"Server: {serverName} Received: {message}");
                p.Reader.AdvanceTo(readResult.Buffer.End);
            }
        }
