    public class CarMake
    {
        public string Name { get; }
        public string PriceMultiplier{ get; }
        public string PenaltyOffset{ get; }
    }
    public class CarModel
    {
        public string Name { get; }
        public string PriceMultiplier{ get; }
        public string PenaltyOffset{ get; }
        public CarMake Make { get; } //since model is dependent on Make. For example BMW models are not same as Toyota models.
    }
    public class CarYear
    {
        public string Name { get; }
        public string PriceMultiplier{ get; }
    }
    public class CarInstance
    {
        public string RegistrationNumber { get; }
        public CarModel Model { get; }
        public CarYear Year{ get; }
    }
