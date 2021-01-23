    public enum Color {Red, Yellow, Blue};
    public enum Size {S, M, L};
    public enum Material {Cotton, Nylon, Blend};
    public class Product
    {
       Color color;
       Size size;
       Material material;
    }
    
    List<Product> products = new List<Product>();
    
    for(int i = 0; i < 3; i++)
       for(int j = 0; k < 3; j++)
           for(int k = 0; k < 3; k++)
           {
            Product p = new Product();
            p.color = i;    // Not sure if this will work exactly like this (with the i)
            p.size = j;     // ""
            p.material = k; // ""
            products.Add(p);
           }
