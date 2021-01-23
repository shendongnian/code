    interface ISome
    {
       void M();
    }
    
    class B : ISome
    {
       public virtual M()
       {
       }
    }
    
    class A : B
    {
       public void override M()
       {
          base.M();
       }
    }
