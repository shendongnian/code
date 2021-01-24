    using System.Net.WebSockets;
    using Newtonsoft.Json.Linq;
    
    var client = new ClientWebSocket();
    var canc = new System.Threading.CancellationToken();
    await client.ConnectAsync(new Uri($"wss://stream.watsonplatform.net/text-to-speech/api/v1/synthesize?access_token={accessToken}&voice=en-US_MichaelV3Voice"), canc);
    var message = new JObject();
    message.Add("accept", JToken.FromObject("audio/wav"));
    message.Add("text", JToken.FromObject(text));
    message.Add("timings", JToken.FromObject(new string[] { "words" }));
    await client.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message.ToString())), WebSocketMessageType.Text, true, canc);
    
    var toReturn = new List<Timing>();
    while (client.State == WebSocketState.Open)
    {
    	var buffer = new byte[4096 * 20];
    	var response = await client.ReceiveAsync(new ArraySegment<byte>(buffer), canc);
    	var data = new List<byte>();
    	if (response.MessageType == WebSocketMessageType.Text)
    	{
    		Console.WriteLine("got a string, it says: " + Encoding.UTF8.GetString(data.ToArray()));
    	}
    }
