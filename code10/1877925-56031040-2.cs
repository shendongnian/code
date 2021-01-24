    public class CollectingData
    {
     public Collection<Countries> CollectCountries ;
     public CollectingData()
     {
     CollectCountries = new Collection<Countries>
     }
    }
    public class Countries
    {
     public string country { get; set;}
     public List<string> states { get; set;}
    } 
