public void MessageHandler(data : IWebSocketResponse) 
{
....
}
And then use it like this :
var socketId = binanceWebSocketClient.ConnectToDepthWebSocket("ETHBTC",this.MessageHandler);
