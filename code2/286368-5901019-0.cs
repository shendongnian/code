    public class PlantWADSUnitsList
    {
      public string Name { get; set; }
      public string Desc { get; set; }
    
      public override string ToString()
      {
        return Name + ": " + Desc;
      }
    }
