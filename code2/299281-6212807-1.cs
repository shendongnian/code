    public abstract class Tile
    {
      public abstract string BaseType;
    }
    
    public class Floor : Tile
    {
      public override string BaseType
      {
        get
        {
           return "floor";
        }
      }
    }
    
    public class Grass : Tile
    {
      public override string BaseType
      {
        get
        {
           return "grass";
        }
      }
    }
    
    public class Wooden : Tile
    {
      public override string BaseType
      {
        get
        {
           return "wooden";
        }
      }
    }
