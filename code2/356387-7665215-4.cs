    public class Customer : ISnaphot<Customer>
    {
        public string Name { get; set; }
        private List<string> _creditCardNumbers = new List<string>();
        public List<string> CreditCardNumbers { get { return _creditCardNumbers; } set { _creditCardNumbers = value; } }
        public Customer TakeSnapshot()
        {
            return new Customer() { Name = this.Name, CreditCardNumbers = new List<string>(this.CreditCardNumbers) };
        }
    }
