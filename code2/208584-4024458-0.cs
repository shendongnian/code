    public class MyDependableClass{
      protected MyApplicationContext Application {get; set;}
      protected MyRequestContext Request {get; set;}
      public MyDependableClass() {
        Dependencies.Inject(this);
      }
    }
