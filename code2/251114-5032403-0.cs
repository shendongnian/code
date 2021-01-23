    public class Customer
    {
        public id {get; set;}
        public name {get; set;}
        etc...
        public virtual IList<Order> Orders {get; protected set;}
    }
