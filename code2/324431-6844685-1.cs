    class basetype{
      public virtual void Handle(){
         // do only for base type 
      }
    } 
    class TypeA : basetype{
      public override void Handle(){
         // do only for Atype
      }
    }
    class TypeB : basetype{
      public override void Handle(){
         // do only for Btype
      }
    }
    foreach(baseType obj in myObjects)
        obj.Handle() 
