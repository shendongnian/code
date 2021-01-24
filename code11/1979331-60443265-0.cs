    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new FakeDbContext();
    
            var lookup = dbContext.BillingSettings.Where(t => t.Types == 1).Select(s => new
            {
                s.StartingValues,
                s.Value
            });
    
            var price = dbContext.Parts
                //.Include(n => n.ProdMaster).ToList() // this will work with real EF DbContext
                //.Where(m => m.Material == id) // this will work with real EF DbContext
                .Select(n =>
                {
                    n.SellingPrice = n.ProductMaster.AverageCost * (lookup.FirstOrDefault(x => n.PartNumber.StartsWith(x.StartingValues))?.Value ?? 1);
                    return n;
                });
    
            Console.ReadKey();
        }
    }
    
    public class FakeDbContext
    {
        public List<Part> Parts { get; set; }
        public List<BillingSettings> BillingSettings { get; set; }
    }
    
    public class ProductMaster
    {
        public decimal AverageCost { get; set; }
    }
    
    public class Part
    {
        public ProductMaster ProductMaster { get; set; }
        public decimal SellingPrice { get; set; }
        public string PartNumber { get; set; }
    }
    
    public class BillingSettings
    {
        public int Types { get; set; }
        public string StartingValues { get; set; }
        public decimal Value { get; set; }
    }
