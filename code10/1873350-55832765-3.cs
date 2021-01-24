    public class Vehicle : IVehicle {
        public string Name { get; set; }
        public string OwnerData { get; set; }
        public string VehicleData { get; set; }
        public void SetOwnerData(string data) {
            OwnerData = data;
        }
        public void SetVehicleData(string data) {
            VehicleData = data;
        }
    }
