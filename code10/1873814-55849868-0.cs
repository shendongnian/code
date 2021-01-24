    public interface IVehicle {}
    public class Car : IVehicle {}
    public class Boat : IVehicle {}
    
    public IVehicle CreateObjectType(JToken token)
    {
        switch (token["type"].Value<string>())
        {
            case "Car":
                return new Car();
            case "Boat":
                return new Boat();
            default:
              throw new ArgumentOutOfRangeException(nameof(token));
        }
    }
