    class GeoObjectPart
    {
      public int Category { get; set; }
      public IEnumerable<GeoObjectPart> Parts { get; set; } 
    }
    
    class GeoObject
    {
     public int ObjectType { get; set; } // do not use Type as a property name!
     public long Id { get; set; }
     public IEnumerable<GeoObjectPart> Parts { get; set; } 
    }
