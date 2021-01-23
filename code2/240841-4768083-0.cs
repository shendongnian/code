    static void Main(string[] args)
    {
        var data = new List<Customer>
                    {
                        new Customer {Id = 1, Name = "Anna"},
                        new Customer {Id = 2, Name = "Bob"},
                        new Customer {Id = 3, Name = "Claire"}
                    };
        var result = data.AsQueryable().TestCustomer();
    }
    private static IQueryable<Customer> TestCustomer(this IQueryable<Customer> source)
    {
        return source.Where(x => x.Id > 1);
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
