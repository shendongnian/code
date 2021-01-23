    public class MyClass
    {
        protected int MyValue = 0;
    }
    public class MySubclass : MyClass
    {
        protected new long MyValue = 0;
    }
    void Test()
    {
        MyClass instance = new MyClass();
        instance.MyValue = 10; // int
        MySubclass instance2 = new MySubclass();
        instance2.MyValue = 10; // long
        MyClass instance3 = (MyClass)instance2;
        int value = instance3.MyValue; // int - value is 0.
    }
