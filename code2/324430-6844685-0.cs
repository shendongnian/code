    class basetype{
      public virtual void Handle(){
         // do only for base type 
      }
    } 
    class TypeA : basetype{
      public void Handle(){
         // do only for Atype
      }
    }
    class TypeB : basetype{
      public void Handle(){
         // do only for Btype
      }
    }
    foreach(baseType obj in myObjects)
        obj.Handle() 
