    public interface ICarInfo {
        CarDetails GetCarInfo(string car);
    }
    
    public class CarDetails {
        public string Color { get; set; }
        public string MaxSpeed { get; set; }
        public string Acceleration{ get; set; }
    }
