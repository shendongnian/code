    public enum Color    {Red, Yellow, Blue};
    public enum Size     {S, M, L};
    public enum Material {Cotton, Nylon, Blend};
    public class Product
    {
       public Color    color;
       public Size     size;
       public Material material;
    }
    
    List<Product> products = new List<Product>();
    
    for(int i = 0; i < Enum.GetValues(typeof(Color)).Length; i++)
       for(int j = 0; k < Enum.GetValues(typeof(Size)).Length; j++)
           for(int k = 0; k < Enum.GetValues(typeof(Material)).Length; k++)
           {
              Product p  = new Product();
              p.color    = (Color)i;
              p.size     = (Size)j;
              p.material = (Material)k;
              products.Add(p);
           }
