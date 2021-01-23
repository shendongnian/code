    class Base
    {
       public MyEnum A = MyEnum.Default;
    }
    
    class Derived : Base
    {
       public new MyEnum A = MyEnum.Changed;
    }
