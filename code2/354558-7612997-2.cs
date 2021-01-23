    class Product : IEquatable<Product>
    {
      public Guid Id { get; set; }
      public bool Equals(Product other) 
      {
        if (ReferenceEquals(null, other)) {
          return false;
        }
        return other.Id == this.Id;
      }
    
      public override bool Equals(object obj) 
      {
        return Equals(obj as Product);
      }    
      
      public override int GetHashCode()
      {
        return Id.GetHashCode();
      }
    }
