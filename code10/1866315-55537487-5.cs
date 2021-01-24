    public class Order
    {
        public int OrderId { get; set; }
        ..............
        public int AddressFromId { get; set; }
        public virtual Address AddressFrom { get; set; }
        public int AddressToId { get; set; }
        public virtual Address AddressTo { get; set; }
        
        ................
    }
