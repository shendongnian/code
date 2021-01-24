    public interface ICarInfo {
        ICarDetails GetCarInfo(string car);
    }
    
    public interface ICarDetails {
        string Color { get; set; }
        string MaxSpeed { get; set; }
        string Acceleration{ get; set; }    
    }
    public class CarDetails : ICarDetails {
        public string Color { get; set; }
        public string MaxSpeed { get; set; }
        public string Acceleration{ get; set; }
    }
