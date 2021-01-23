    public class Product
    {
     int productID;
     string name;
    }
    
    public class Order
    {
     int orderID;
     Customer customer;
     List<Product> products;
     DateTime orderDate;
    }
