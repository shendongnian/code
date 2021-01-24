    [Table("Cars")]
    public abstract class Car : Product
    {
        public string ChassisNumber { get; set; }
        public string DriverName { get; set; }
    }
    [Table("TeslaCars")]
    public class TeslaCar : Car
    {
        public string Battery { get; set; }
        public int Temperature { get; set; }
    }
    [Table("PorscheCars")]
    public class PorscheCar : Car
    {
        public int FuelTank { get; set; }
    }
