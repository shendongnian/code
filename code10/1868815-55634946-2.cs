    public class NonGenericClass {}
    public class OtherGenericClass<T>{}
    public class GenericClass<T,T2>
        where T: OtherGenericClass<T2>, new()
        where T2: NonGenericClass
    {
        public T Foo()
        {
            return new T();
        }
    }
