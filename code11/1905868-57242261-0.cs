namespace MyCore.Utils
{
    public class WebSocketClient
    {
        public static string StartWSSession(string url, string cmd)
        {
            string reply = null;
            using (var ws = new WebSocketSharp.WebSocket(url))
            {
                int received = 0;
                // Set the WebSocket events.
                ws.OnOpen += (sender, e) =>
                {
                    Response jsonmsg = new Response();
                    jsonmsg.Identifier = 2000;
                    jsonmsg.Message = cmd;
                    jsonmsg.Name = "PowershellWS";
                    string output = JsonConvert.SerializeObject(jsonmsg);
                    ws.Send(output);
                };
                ws.OnMessage += (sender, e) => {
                    Response response = JsonConvert.DeserializeObject<Response>(e.Data);
                    if (response.Identifier == 2000) {
                        Console.WriteLine(response.Message);
                        reply = response.Message;
                        received ++;
                        ws.Close();
                    }
                };
                ws.OnError += (sender, e) =>
                    Console.WriteLine(e.Message);
                ws.OnClose += (sender, e) =>
                    Console.WriteLine(e.Reason);
                // Connect to the server.
                ws.Connect();
                while (received < 1){Thread.Sleep(1);}
            }
            return reply;
        }
        
    }
    internal class Response
    {
        [JsonProperty(PropertyName = "Identifier")]
        public int Identifier { get; set; }
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
I took PS for granted, now use a return for the variable reply i made so it actually returns a value and the function itself can't be void, since that means it isn't returning anything at all, it has to be a "string"
