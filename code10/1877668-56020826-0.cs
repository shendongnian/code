    public class Car
    {
        public string Trademark { get; set; }
        public int YearMade { get; set; }
        public int Mileage { get; set; }
        public int RegPlate { get; set; }
        public Car (string Trademark, int RegPlate, int YearMade, int Mileage)
        {
            this.Trademark = Trademark;
            this.RegPlate = RegPlate;
            this.YearMade = YearMade;
            this.Mileage = Mileage;
        }
    }
    
    public class Driver
    {
        public string Name { get; set; }
        public int RegPlate { get; set; }
        public Driver(string Name , int RegPlate )
        {
            this.Name = Name;
            this.RegPlate = RegPlate ;
        }
    }
    
    public class Taksi : Car
    {
        public Driver TaksiDriver { get; set; }
        public Taksi(Driver TaksiDriver, Car TaksiCar)
          : base(TaksiCar.Trademark, TaksiCar.RegPlate, TaksiCar.YearMade, TaksiCar.Mileage)
        {
            this.TaksiDriver = TaksiDriver;
        }
    }
