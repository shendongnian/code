    public class CarModel
    {
        public string Name { get; }
        public string Class { get; }
        public string Engine { get; }
    }
    public class CarInstance
    {
        public readonly CarModel CarModel;
        public uint Mileage { get; }
        public uint IssueYear { get; }
    }
