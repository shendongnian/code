    public class MyClass
    {
      Int32 MyBoxedValueType; //using "int" not legal
    }
    
    ...
    
    MyClass myClass = new MyClass();
    int theInt = 2;
    
    myClass.MyBoxedValueType = (Int32)theInt; //explicit cast required
