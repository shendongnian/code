    public interface IBeverage
    {
      string GetDescription ();
    }
    
    public abstract class BeverageBase : IBeverage
    {
      public virtual string GetDescription () { return "Unknown Beverage"; }
    }
    
    public class DarkRoast : BeverageBase { ... }
    public class HouseBlend : BeverageBase { ...}
    
    public abstract class CondimentBase : IBeverage
    {
      public CondimentBase(IBeverage beverage)
      {
        Beverage = beverage;
      }
      protected IBeverage Beverage { get; set; }
      public abstract string GetDescription ();
    }
    public class Mocha : CondimentBase 
    {
      public Mocha(IBeverage beverage)
        : base (beverage)
      { }
      public string GetDescription()
      {
        return Beverage.GetDescription() + ", Mocha";
      }
    }
