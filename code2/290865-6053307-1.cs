    interface I<T1>
    {
        void Foo<T2>() where T2 : T1;
    }
    class C : I<MyClass>
    {
        public void Foo<T>() where T : MyClass { }
    }
    public class MyClass
    {
    }
