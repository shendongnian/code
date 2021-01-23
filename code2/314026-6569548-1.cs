    class A
    {
      private int attr
    
      public int Attr
      {
         get { return attr; }
         set { attr = value }
      }
    
      public A()
      {
      }
      
      public A(A p)
      {
         this.attr = p.Attr;
      }  
    }
