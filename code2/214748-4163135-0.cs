    public class Product
    {
       //others can't create instances outside the namespace
       internal Product() { }    
    }
    public class ProductProvider
    {
       //they can only get standardized products by the provider
       //while you have full control to Product class inside ProductProvider
       public static CreateProduct()
       {
           //can create an instance here because they are in the same namespace
           Product p = new Product();    
           //standardize the product
           return p;
       }  
    }
