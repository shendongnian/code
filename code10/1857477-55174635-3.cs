    public class ProductColourSummary
    {
       public string ProductName { get; set; }
       public List<string> Colors { get; set; } = new List<string>();
    
       public string FlattenedColors
       {
           get { return string.Join(", ", Colors); }
       }
    }
    var results = context.ProductColors
        .Select(x => new {ProductName = x.Product.Name, ColorName = x.Color.Name})
        .GroupBy(x => x.ProductName)
        .Select( group => new ProductColorSummary
        {
            ProductName = group.Key, // Product.Name
            Colours = group.Select(x=> x.ColourName).ToList()
        }).ToList();
