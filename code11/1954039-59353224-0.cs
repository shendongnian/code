    public class Car
    {
        public int CarId { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
    public class Owner
    {
        public int OwnerId { get; set; }
        public int CarId { get; set; }
        public string nic { get; set; }
    }
    public class CarOwner
    {
        public int CarID { get; set; }
        public string OwnerNIC { get; set; }
    }
