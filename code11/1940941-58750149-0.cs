    public class CarInfo : ICarInfo {
        Motor Motor { get; set; }
        Wheels Wheels { get; set; }
        String Category{ get; set; }
    
        public CarInfo(Motor motor, Wheels wheels, string category)
        {
            this.Motor = motor;
            this.Wheels = wheels;
            this.Category = category;
        }
    }
