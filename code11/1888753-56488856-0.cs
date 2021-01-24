    class Program
    {
        static void Main(string[] args)
        {
            FlagMotorBicycle fmb = new FlagMotorBicycle();
            Console.WriteLine("{0} {1}", fmb.FlagColor, fmb.Name);
            Console.ReadLine();
        }   
    }
    public interface IVehicle
    {
        string Name { get; }
    };
    public class Car : IVehicle
    {
        public string Name { get; private set; }
        public Car()
        {
            this.Name = "Car";
        }
    };
    public class MotorBicycle : IVehicle
    {
        public string Name { get; private set; }
        public MotorBicycle()
        {
            this.Name = "Bicycle";
        }
    };
    public interface IFlagVechile
    {
        string FlagColor { get; }
    };
    public class TFlagVechicle<T> :
        IVehicle, IFlagVechile
        where T : class, IVehicle, new()
    {
        private T t;
        public TFlagVechicle()
        {
            this.t = new T();
            this.FlagColor = "Red";
        }
        public string FlagColor { get; private set; }
        public string Name
        {
            get
            {
                return t.Name;
            }
        }
    };
    public class FlagCar : TFlagVechicle<Car>
    {
    };
    public class FlagMotorBicycle : TFlagVechicle<MotorBicycle>
    {
    };
 
