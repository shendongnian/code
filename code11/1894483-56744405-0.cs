    public class JsonModel{
    public string Tag {get;set;}
    public double Probability {get;set;}
    }
    var model = JsonConvert.DeserializeObject<List<JsonModel>>(message);
