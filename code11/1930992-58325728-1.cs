    public interface ICar
    {
        string Name { get; set; }
        int Doors { get; set; }
        string EngineCapacity { get; set; }
    }
b.Abstract Car Factory
    public abstract class AbstractCarFactory
    {
        public abstract ICar CreateCar(CarType type);
    }
c.Two Concrete Cars - 
    internal class NissanPickUpTruck : ICar
    {
        public string Name { get; set; } 
        public int Doors { get; set ; }
        public string EngineCapacity { get ; set ; }
    }
    internal class NissanSportsCar: ICar
    {
        public string Name { get; set; } 
        public int Doors { get; set; }
        public string EngineCapacity { get; set; }
    }
d.Concrete Factory
    public class NissanFactory : AbstractCarFactory
    {
        public override ICar CreateCar(CarType type)
        {
            switch (type)
            {
                case CarType.PickupTruck:
                    return new NissanPickUpTruck{Name = "Titan", Doors = 6, EngineCapacity = "V12"};
                case CarType.SportsCar:
                    return new NissanSportsCar{Name = "350Z", Doors = 2, EngineCapacity = "V6"};
                default:
                    throw new Exception();
            }
        }
    }
Finally the calls from an external project
            var nissanFactory = new NissanFactory();
            var sportsCar = nissanFactory.CreateCar(CarType.SportsCar);
            var pickUpTruck = nissanFactory.CreateCar(CarType.PickupTruck);
**But like the other comment, the Builder is something worth checking out as well.**
