    public class MyClass
    {
      Object MyObjectReference;
    }
   
    ...
    
    MyClass myClass = new MyClass();
    int theInt = 2;
    
    myClass.MyObjectReference = (Int32)theInt; //illegal
    myClass.MyObjectReference = (Object)theInt; //required
