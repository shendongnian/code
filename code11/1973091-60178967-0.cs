    private static async Task DoClientWebSocket()
    {
        using (ClientWebSocket ws = new ClientWebSocket())
        {
            Uri serverUri = new Uri("wss://echo.websocket.org/");
            //Implementation of timeout of 5000 ms
            var source = new CancellationTokenSource();
            source.CancelAfter(5000);
    
            await ws.ConnectAsync(serverUri, source.Token);
            var iterationNo = 0;
            // restricted to 5 iteration only
            while (ws.State == WebSocketState.Open && iterationNo++ < 5)
            {
                string msg = "hello123";
                ArraySegment<byte> bytesToSend = 
                             new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));
                await ws.SendAsync(bytesToSend, WebSocketMessageType.Text,
                                   true, source.Token);
                ArraySegment<byte> bytesReceived = 
                             new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await ws.ReceiveAsync(bytesReceived, 
                                                            source.Token);
                Console.WriteLine(Encoding.UTF8.GetString(bytesReceived.Array, 0,
                                                            result.Count));
            }
        }
    }
    
    static void Main(string[] args)
    {
        var taskWebConnect = Task.Run(() => DoClientWebSocket());
    
        taskWebConnect.Wait();
    }
