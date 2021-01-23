    abstract class MyBase<T>
    {
       public static void MyMethod()
       {
          var myActualType = typeof(T);
          doSomethingWith(myActualType);
       }
    }
    
    
    class MyImplementation : MyBase<MyImplementation>
    {
        // stuff
    }
