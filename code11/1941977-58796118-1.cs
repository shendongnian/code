    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [BindProperty(BinderType = typeof(DecimalModelBinder))]
        public decimal Price { get; set; }
    }
