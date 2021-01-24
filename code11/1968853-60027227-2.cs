    [Table("Motorcycles")]
    public abstract class Motorcycle : Product
    {
        public string RiderName { get; set; }
        public bool IsRacing { get; set; }
    }
    [Table("CrossMotorcycles")]
    public class CrossMotorcycle : Motorcycle
    {
        public int MaximumJump { get; set; }
    }
    [Table("KipsMotorcycles")]
    public class KipsMotorcycle : Motorcycle
    {
        public long MaximumSpeed { get; set; }
    }
