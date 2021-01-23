    public class Driver
    {
        private string vehicleTypeName;
        private IVehicle vehicle;
    
        public IVehicle Vehicle
        {
            get
            {
                if (vehicle == null)
                {
                    vehicle = typeof(IVehicle).Assembly
                                       .CreateInstance(vehicleTypeName);
                }
                return vehicle;
            }
        }
    }
