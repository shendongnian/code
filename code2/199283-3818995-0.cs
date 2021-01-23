    public interface IAddress
    {
        public string streetno { get; set; }
        public string streetname { get; set; }
        public string suburb { get; set; }
        public string postcode { get; set; }
        public Country country { get; set; }
    }
        
    public class Person<A>
        where A : IAddress
    {
        public A address;
    
        public Person()
        {
            address.country = new Country();
        }
    }
