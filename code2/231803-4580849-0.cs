    public class Product
    {
      public string Colour { get; set; }
      public string Size { get; set; }
      public string Material { get; set; }
    }
    IList<Product> products = new List<Product>();
    foreach (string colour in colours)
    {
      foreach (string size in sizes)
      {
        foreach (string material in materials)
        {
          products.Add(new Product 
          {
            Colour = colour,
            Size = size,
            Material = material
          });
        }
      }
    }
