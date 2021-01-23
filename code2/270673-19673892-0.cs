      public class User : List<UserData>
        {
        
            public int id { get; set; }
            public string screen_name { get; set; }
        
        }
        
        
        string json = client.DownloadString(url);
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var Data = serializer.Deserialize<List<UserData>>(json);
