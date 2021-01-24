        static async Task StartUdpListener()
        {
            // Use a Dictionary to match packets from given connections to give Pipes
            ConcurrentDictionary<string, Pipe> connections = new ConcurrentDictionary<string, Pipe>();
            var udpServer = new UdpClient(new IPEndPoint(IPAddress.Any, 33000));
            while (true)
            {
                // Wait for some data to arrive
                var result = await udpServer.ReceiveAsync();
                
                if(connections.ContainsKey(result.RemoteEndPoint.ToString()))
                {
                    // If we have seen this IPEndpoint before send the traffic to the pipe
                    // the task associated with that Pipe willpick the traffic up
                    connections.TryGetValue(result.RemoteEndPoint.ToString(), out var p);
                    await p.Writer.WriteAsync(result.Buffer);
                }
                else
                {
                    // If we have not seen it, make the pipe, stick the data in the pipe
                    // and spin up a task to Read/Process the data
                    var p = new Pipe();
                    connections.TryAdd(result.RemoteEndPoint.ToString(), p);
                    await p.Writer.WriteAsync(result.Buffer);
                    _ = Task.Run(() => UdpServerClient(result.RemoteEndPoint.ToString(), p));
                }
            }
        }
