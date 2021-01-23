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
    int numColors    = Enum.GetValues(typeof(Color)).Length;
    int numSizes     = Enum.GetValues(typeof(Size)).Length;
    int numMaterials = Enum.GetValues(typeof(Material)).Length;
    
    for(int i = 0; i < numColors; i++)
       for(int j = 0; k < numSizes; j++)
           for(int k = 0; k < numMaterials; k++)
           {
              Product p  = new Product();
              p.color    = (Color)i;
              p.size     = (Size)j;
              p.material = (Material)k;
              products.Add(p);
           }
