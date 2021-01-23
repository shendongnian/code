    public class MyObject {
      protected MyObject myObjectInstance;
      public MyObject MyObjectInstance {
        get { return (myObjectInstance == null)? this: myObjectInstance;
        set { myObjectInstance = value; }
      }
    }
