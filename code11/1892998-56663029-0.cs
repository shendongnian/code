    public class Person
    {
     public int Id {get;set;}
     public string Name {get;set;}
     public string Address {get;set;}
     public string Country {get;set;}
     public string Phone {get;set;}
    }
    
    var details = JsonConvert.DeserializeObject<Person>(json);
