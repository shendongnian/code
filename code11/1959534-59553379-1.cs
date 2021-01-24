public void MessageHandler(IWebSocketResponse data)
{
....
}
And then use it like this :
var socketId = binanceWebSocketClient.ConnectToDepthWebSocket("ETHBTC",this.MessageHandler);
