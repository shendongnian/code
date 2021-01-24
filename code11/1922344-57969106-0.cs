    public class Source
    {
       public string Product {get;set;}
       public List<Dictionary<string,string>> To_Description{get;set;}
    }
    
    
    public class Destination
    {
       public string Product {get;set;}
       public Dictionary<string,string> To_Description{get;set;}
    }
