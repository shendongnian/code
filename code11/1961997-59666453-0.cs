    public class LastTighteningResultData {
        public string LastTighteningResultDataRev3 {get;set;}
        public IEnumerable<string> Attribute {get;set;}
    }
    var data = JsonConvert.DeserializeObject(jsonobj);
    foreach (var resultData in data) 
    {
        // do stuff here with resultData.LastTighteningResultDataRev3 & resultData.Attribute
    }
