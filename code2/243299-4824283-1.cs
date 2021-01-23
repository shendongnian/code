    class Car
    {
        string model;
        public Car(string model) { this.model = model; }
        protected Car(Car other) { this.model = other.model; }
        string Model { get; set; }
    }
    class SuperCar : Car
    {
        public SuperCar(Car car) : base(car) { }
        public SuperCar(string model) : base(model) { }
        bool IsTurbo { get; set; }
    }
