    public class Car {
    
        public class CarOptions
        {
            public string SeatFinish { get; set; }
            public string Audio { get; set; }
        }
    
        public string Model { get; set; }
        public CarOptions Options { get; set; }
    
        public Car()
        {
            this.Options = new CarOptions();
        }
    }
