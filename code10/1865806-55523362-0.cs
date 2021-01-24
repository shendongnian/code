cs
public class Bicycle {
   public IWheelSettings MyWheelSettings { get; set; } = new WheelSettings();
   public interface IWheelSettings {
      decimal SpokeLength { get; set; }
   }
   private class WheelSettings : IWheelSettings {
      public decimal SpokeLength { get; set; }
   }
}
This way you can prevent anyone _instantiating_ instances of `IWheelSettings`, since no class that implements it is publicly known.  
Of course, nothing is preventing me from implementing it myself.
BTW, any other class would need to qualify `WheelSettings` with `Bycicle` anyway, so it's pretty obvious that it shouldn't be used in other context already.
cs
public class Car {
	public Bicycle.WheelSettings settings;
}
EDIT: Also, consider this: If instances of `WheelSettings` should never be referenced without the `Bicycle`, why does it exist? Why aren't wheel settings properties of the `Bicycle` itself?
