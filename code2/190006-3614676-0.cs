    public class Vehicle
    {
        public void StartEngine()
        {
            // Code here.
        }
    
        //For demo only; a method like this should probably be static or external to the class
        public void GentlemenStartYourEngines(List<Vehicle> otherVehicles)
        {
           otherVehicles.Add(this);
    
           foreach(Vehicle v in Vehicles) v.StartEngine();
        }
    }
