    In same class, create two functions returning boolean like this:
    
     public bool ShouldSerializedt()
     {
          return false;
     }
    
     public bool ShouldSerializeCategory()
     {
          return false;
     }
    
    Function returns boolean. Its name is "ShouldSerialize<<PropertyName>>" and the return type of boolean controls serialization behavior
