    public class MyList: List<MyClass> {
      private readonly static MyList instance = new MyList();
    
      private MyList() { }
    
      public static MyList Instance 
      { 
        get 
        {
           return instance;
        }
      }
    }
