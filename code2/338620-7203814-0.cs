    static string TheJson = "...";
    public class TheType
    {
        public int id { get; set;}
        public string name { get; set; }
    }
    var serializer = new JavaScriptSerializer();
    var deserialized = serializer.Deserialize<List<TheType>>(TheJson);
