    public class Unit {
    
      public Unit(string name)
      {
         NameOfField = name;
      }
      public string NameOfField { get; private set;} }
    }
    
    public static Unit Hectare = new Unit("Hectare");
