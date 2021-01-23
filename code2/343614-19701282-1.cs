    public class PersonModel
    {
      // helper properties
      public bool LocationNotSet { get { return string.IsNullOrEmpty(Location); } }       
      public bool NameAndAgeNotSet { get { return string.IsNullOrEmpty(Name) && Age <= 0; } }
      [RequiredIf("LocationNotSet")] // Requried if Location is not set
      public string Name {get; set;}
      [Range( 1, 5 ), RequiredIf("LocationNotSet")] // Requried if Location is not set
      public int Age {get; set;}
    
      [RequiredIf("NameAndAgeNotSet")] // Only required if Name and Age are not set.
      public string Location {get; set;}
    }
