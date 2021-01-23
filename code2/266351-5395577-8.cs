    class VehicleProgram
    {
        //All vehicle classes implement their own engine starter method that has this signature
        delegate void StartEngine();
        static void Main()
        {
            //The Main doesn't know the details of starting an engine.
            //It delegates the responsibility to the concrete vehicle class
            foreach (StartEngine starter in GetVehicleStarters())
            {
                starter(); //Invoke the method
            }
    
            Console.ReadLine();
        }
    
        static List<StartEngine> GetVehicleStarters()
        {
            //Create a list of delegates that target the engine starter methods
            List<StartEngine> starters = new List<StartEngine>();
    
            starters.Add(Car.StartCar);
            starters.Add(Motorcycle.StartMotorcycle);
            starters.Add(Airplane.StartAirplane);
    
            return (starters);
        }
    
        class Car
        {
            public static void StartCar()
            {
                Console.WriteLine("The car is starting.");
            }
        }
    
        class Motorcycle
        {
            public static void StartMotorcycle()
            {
                Console.WriteLine("The motorcycle is starting.");
            }
        }
    
        class Airplane
        {
            public static void StartAirplane()
            {
                Console.WriteLine("The airplane is starting.");
            }
        }
    }
