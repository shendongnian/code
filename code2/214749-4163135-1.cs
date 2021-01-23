    public class Product
    {
       //others can't create instances directly outside the assembly
       internal Product() { }    
    }
    public class ProductProvider
    {
       //they can only get standardized products by the provider
       //while you have full control to Product class inside ProductProvider
       public static Product CreateProduct()
       {
           Product p = new Product();    
           //standardize the product
           return p;
       }  
    }
