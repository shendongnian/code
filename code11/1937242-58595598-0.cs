    public class Product{
       private string _name;
       public decimal Price {get;}
    
       public Product(string name, decimal price){
          _name = name;
          Price = price;
       }
       public override string ToString(){
         return _name;
       }
    }
