    interface ICarProvider
    {
        Car GetCarById(int id);
        ICollection<Car> GetAllCars();
    }
    
    public CarProvider : ICarProvider { ... }
    // ^ implementation that loads Car objects, e.g. from a relational database
    
    public class Car
    {
        public int Id { get; private set; }
        public ICollection<Door> Doors { get; private set; }
    
        public Car(int id, IDoorProvider doorProvider)
        {
            this.Id = id;
            this.Doors = doorProvider.GetDoorsOfCar(this);
        }
        ...
    }
    
    public interface IDoorProvider
    {
        ICollection<Door> GetDoorsOfCar(Car car);
        ...
    }
    
    public class DoorProvider : IDoorProvider { ... }
    // ^ similar to CarProvider, but loads data for Doors instead.
    
    public class Door
    {
        public int Id { get; private set; }
        public ICollection<Hinge> Hinges { get; private set; }
    
        public Door(int id, IHingeProvider hingeProvider)
        {
            this.Id = id;
            this.Hinges = hingeProvider.GetHingesOfDoor(this);
        }
        ...
    }
    
    ...
