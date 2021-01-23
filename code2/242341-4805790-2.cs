    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ApplicationInstance
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int CustomerId { get; set; }
        public Application Application { get; set; }
        public Customer Customer { get; set; }
    }
