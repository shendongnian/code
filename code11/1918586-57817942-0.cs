     public static void Json()
                {
                    string url = "https://data.ny.gov/resource/d6yy-54nr.json";
                    WebRequest request = WebRequest.Create(url);
                    WebResponse reply;
                    reply = request.GetResponse();
                    StreamReader returninfo = new StreamReader(reply.GetResponseStream());
                    string getinfo = returninfo.ReadToEnd();
                    List<Draw> Info = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Draw>>(getinfo);
                    foreach (var info in Info)
                    {
                   
        
            
                    }
     public class Draw
        {
            public DateTime draw_time { get; set; }
            public string winning_numbers { get; set; }
            public string multiplier { get; set; }
        }
