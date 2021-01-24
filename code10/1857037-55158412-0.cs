    public class Data
    {
        public string ImageString { get; set; }
    }
    var data = Newtonsoft.Json.JsonConvert.Deserialize<Data>(_strings);
    var myImageString = data.ImageString;
