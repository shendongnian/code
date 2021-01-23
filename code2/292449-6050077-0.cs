    public class User
    {
        public virtual Guid ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ShopperInfo { get; set; }
    }
    public class ShopperInfo
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
