    Can you try this
    public class CustomKeys
        {
        public string dataA { get; set; }
        public string dataB { get; set; }
        }
    public class Customer 
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<CustomKeys> customKeys { get; set; }
    }
    Customer customer = new Customer
    {
        id = id,
        name = customerName,
        customKeys = new List<CustomKeys>(){
    dataA ="dataA",
    dataB ="dataB "};
    };
