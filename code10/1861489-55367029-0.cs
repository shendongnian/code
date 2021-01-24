    public class Employee 
    {
    public int Id {get;set;}
    public string FullName {get;set;}
    public string NameAndIdCombined => $"{FullName} - ID: {Id.ToString()}"
    }
