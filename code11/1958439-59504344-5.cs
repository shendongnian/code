    public class Product : IEquatable<Product>
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public bool Equals(Product other)
        {
            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(other, null)) return false;
            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;
            //Check whether the products' properties are equal. 
            return Code.Equals(other.Code) && Name.Equals(other.Name);
        }
        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 
        public override int GetHashCode()
        {
             //Get hash code for the Name field if it is not null. 
             int hashProductName = Name == null ? 0 : Name.GetHashCode();
             //Get hash code for the Code field. 
             int hashProductCode = Code.GetHashCode();
             //Calculate the hash code for the product. 
             return hashProductName ^ hashProductCode;
         }
    }
    //Code example
    Product[] products = { new Product { Name = "apple", Code = 9 }, 
                           new Product { Name = "orange", Code = 4 }, 
                           new Product { Name = "apple", Code = 9 }, 
                           new Product { Name = "lemon", Code = 12 } };
    
    //Exclude duplicates.
    
    IEnumerable<Product> noduplicates =
        products.Distinct();
    
    foreach (var product in noduplicates)
        Console.WriteLine(product.Name + " " + product.Code);
    
    /*
        This code produces the following output:
        apple 9 
        orange 4
        lemon 12
    */
