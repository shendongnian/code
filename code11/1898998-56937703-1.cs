    abstract class Parent<T>
    {
      protected T DB;
      public void Disconnect()
      {
        DB.Disconnect();
      }
    }
    
    class Child1 : Parent<IDB_Child1>
    {
    }
    class Child2 : Parent<IDB_Child2>
    {
    }
