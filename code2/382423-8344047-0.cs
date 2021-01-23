    public class MyObject
    {
      public string name { get;set; }
      public string type { get;set; }
      public Location location { get;set; }
      public Owner owner { get;set; }
    }
    
    public class Location
    {
      public int id { get;set; }
      public string name { get;set; }
    }
    
    public class Owner
    {
      public int id { get;set; }
      public string name { get;set; }
    }
