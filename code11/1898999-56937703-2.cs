    abstract class Parent
    {
      protected IDB DB() {get;}
      public void Disconnect()
      {
        getDB().Disconnect();
      }
    }
    
    class Child1 : Parent
    {
      protected IDB_Child1 _DB;
      override IDB DB() 
      {  
          get 
          {
              return DB;
          }
      }
    }
    class Child2 : Parent
    {
      protected IDB_Child2 _DB;
      override IDB DB() 
      {  
          get 
          {
              return DB;
          }
      }
    }
