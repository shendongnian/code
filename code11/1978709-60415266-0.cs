    public class Data{
        public string value{get;set;}
        public string Type{get;set;}
    }
        
    var testClass = JsonConvert.DeserializeObject<List<Data>>(input);   
    
