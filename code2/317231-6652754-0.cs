    public class LoadInformationModel 
    {
      public string StudentCode { get; set; }
      public string FirstName { get; set; }
      // etc..
    
      public ICollection<Damage> Type { get; set; }
    }
