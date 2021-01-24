    public class Car
    {
        private string VehicleType;
        private string BoxPlate;
        private string BoxColour;
        private string BoxMake;
        private DateTime CreationTime;
        private string ParkingSpotInput;
        public Car(string vehicleType, string boxPlate, string boxMake, string boxColour, DateTime creationTime, string parkingSpot)
        {
            this.VehicleType = vehicleType;
            this.BoxPlate = boxPlate;
            this.BoxColour = boxColour;
            this.CreationTime = creationTime;
            this.ParkingSpotInput = parkingSpot;
        }
        public override string ToString()
        {
            return $"VehicleType: {this.VehicleType}, BoxPlate: {this.BoxPlate}, BoxColour: {this.BoxColour}");
        }
    }
