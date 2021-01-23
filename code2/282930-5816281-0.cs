    public class Customer
    {
        public Customer()
        {
            PhoneList = new List<PhoneNumber>();
        }
        public Customer(int id, string name)
            : this()
        {
            this.CustomerID = id;
            this.CustomerName = name;
        }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<PhoneNumber> PhoneList { get; set; }
    }
