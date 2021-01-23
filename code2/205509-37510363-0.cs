    interface MyInterface
    {
      void MyFunction();
    }
    public class MyClass : MyInterface
    {
      [Export(typeof(MyInterface))]
      void MyFunction() { }
    }
