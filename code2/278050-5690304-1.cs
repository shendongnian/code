    Entity<InheritingType>
      where InheritingType : Entity<InheritingType>
    {
    
      public T Move(Position newPosition)
      {
          T result = this.Clone();
          result.Position = newPosition;
          return result;
      }
    
      private T Clone() 
      {
         //create a new instance of ourselves using reflection
        //i.e. reflect all the protected properties in the type (or fields if you don't want     even protected properties) , and set them
        //you could also have the Clone method be abstract and force it's implementation in all inheriting types
         
      }
    }
