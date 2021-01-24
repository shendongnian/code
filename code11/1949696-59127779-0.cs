    class Program
    {
        static void Main(string[] args)
        {
            Customer Cust = new Customer();
            List<Customer> Customers = Cust.GetCustomers();
            foreach(Customer c in Customers)
            {
                Console.WriteLine(c.Name);
            }
            Console.Read();
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Status { get; set; }
        List<Customer> Customers = new List<Customer>();
        public  List<Customer> GetCustomers()
        { 
            //Your Foreach Logic will be replaced
        for(int i=0;i<3;i++)
            {
                if (i % 2 == 0)
                {
                    Customers.Add(new Customer { Id = i, Name = "Name" + i, Status = "Success Message" });
                }
                else
                {
                    Customers.Add(new Customer { Id = i, Name = "Name" + i, Status = "Error Message" });
                }
            }
            return Customers;
        }
    }
