    public class Car : Vehicle { }
    public class Truck : Vehicle { }
    public abstract class Vehicle
    {
        private static readonly IReadOnlyDictionary<Type, Func<Vehicle>> vehicleFactories = new Dictionary<Type, Func<Vehicle>>
        {
            { typeof(Car), () => new Car() },
            { typeof(Truck), () => new Truck() }
        };
        public static Vehicle Create<T>() where T : Vehicle, new()
        {
            if (vehicleFactories.TryGetValue(typeof(T), out var factory))
            {
                return factory();
            }
            else
            {
                throw new ArgumentException(
                    $"The type {typeof(T).Name} is not known by this method.");
            }
        }
    }
