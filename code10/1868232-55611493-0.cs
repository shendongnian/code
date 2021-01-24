    public class Customer
    {
        public int Id { get; set; }
        public List<KartelesPelaton> KartelesPelaton { get; set; }
        public override string ToString() => "Id " + this.Id + ":" + String.Join(", ", this.KartelesPelaton.Select(s => s));
    }
    public class KartelesPelaton
    {
        public bool IsInvoice { get; set; }
        public int Credit { get; set; }
        public int Charge { get; set; }
        public override string ToString() => "Is " + (this.IsInvoice ? "" : "NOT ") + "Invoice! " + Credit + " - " + Charge;
    }
    
    public static void Main(string[] args)
    {
        // Some example-data..
        List<Customer> CustomerList = new List<Customer>()
        {
            new Customer() { Id = 1, KartelesPelaton = new List<KartelesPelaton>() { new KartelesPelaton() { IsInvoice = false, Credit = 1 } } },
            new Customer() { Id = 2, KartelesPelaton = new List<KartelesPelaton>() { new KartelesPelaton() { IsInvoice = true, Credit = 2 }, new KartelesPelaton() { Credit = 22 } } },
            new Customer() { Id = 3, KartelesPelaton = new List<KartelesPelaton>() { new KartelesPelaton() { IsInvoice = true, Credit = 3 } } },
        };
    
        // Let's see what we got..
        Console.WriteLine("Before:");
        foreach (Customer c in CustomerList)
        {
            Console.WriteLine(c);
        }
    
        // Select items to modify (customers seem not to be important here..)
        var itemsToModify = CustomerList.SelectMany(c => c.KartelesPelaton);
        // Process the items
        Parallel.ForEach(itemsToModify, k => { if (k.IsInvoice) k.Charge = k.Credit; });
    
        Console.WriteLine("After:");
        foreach (Customer c in CustomerList)
        {
            Console.WriteLine(c);
        }
    }
