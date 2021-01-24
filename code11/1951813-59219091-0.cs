    public class Customers
    {
        public Customers()
        {
            Itemlst = new List<Customers>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Customers> Itemlst { get; set; }
    }
