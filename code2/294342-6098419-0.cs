    interface IVehicle
    {
        void Go();
    }
    public class Car:IVehicle
    {
        public void Go()
        {
            Console.WriteLine("Drive");
        }
    }
    
    public class SuperCar:IVehicle
    {
        public void Go()
        {
            Console.WriteLine("Drive fast!!");
        }
    }
    IVehicle car = new Car();
    car.Go(); //output Drive
    car = new SuperCar();
    car.Go(); //output Drive fast!!
