    public class Product 
    {
        public Guid Id {get;set;}
    
        public virtual void DoStuff() {}
    }
    
    public class ProductWithSpecialProcessing : Product
    {
        public override void DoStuff() {}
    }
    
    public void ProcessOrder(IEnumerable<Product> products)
    {
        foreach(var product in products)
        {
            product.DoStuff();
        }
    }
