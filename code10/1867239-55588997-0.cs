     public class Listener
        {
            public void StopListening()
            {
                this.src.Cancel();
            }
            private Task listenTask;
            private CancellationTokenSource src=new CancellationTokenSource();
            public Task Listen(string url)
            {
            
               listenTask = Task.Run(async () =>
                {
                    try
                    {
                        byte[] buffer = new byte[1024];
                        await socket.ConnectAsync(new Uri(url), CancellationToken.None);
                        while (true)
                        {
                            WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
                            string data = Encoding.UTF8.GetString(buffer, 0, result.Count);
                            Console.WriteLine(data);
                        }
                    }
                    catch (Exception ex)
                    {
                        //treat exception
                    }
                },src.Token);
            }
        }
