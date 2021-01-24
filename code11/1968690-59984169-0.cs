namespace FtxApi_Test
{
    class Program
    {
        static void Main()
        {
            var client = new Client("_T68V7HmuHoiHlKmpUcOcbNOXkNWpzL-FvpO1VMa", "TsmQWQ4bXrOHzCVbD7vFzZtI-gs7j8tvh684hPY6");
            var api = new FtxRestApi(client);
            var wsApi = new FtxWebSocketApi("wss://ftx.com/ws/");
            WebSocketTests(wsApi, client).Wait();
            Console.ReadLine();
        }
        private static async Task WebSocketTests(FtxWebSocketApi wsApi, Client client)
        {
            var ins = "BTC-PERP";
            
            wsApi.OnWebSocketConnect += () =>
            {
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetAuthRequest(client));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("orderbook", ins));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("trades", ins));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("ticker", ins));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("fills"));
                wsApi.SendCommand(FtxWebSockerRequestGenerator.GetSubscribeRequest("orders"));
            };
            await wsApi.Connect();
        }
    }
}
