    class Program
    {
        static void Main(string[] args)
        {
            Truck truck = new Truck();
            TellMeHowManyWheelsThisHas(truck);
        }
        private static void TellMeHowManyWheelsThisHas(Vehicle vehicle)
        {
            Console.WriteLine("This vehicle has {0} wheels", vehicle.HowManyWheelsDoIHave());
        }
    }
    abstract class Vehicle
    {
        public abstract int HowManyWheelsDoIHave();
    }
    class Car : Vehicle
    {
        public override int HowManyWheelsDoIHave()
        {
            return 4;
        }
    }
    class Truck : Vehicle
    {
        public override int HowManyWheelsDoIHave()
        {
            return 8;
        }
    }
