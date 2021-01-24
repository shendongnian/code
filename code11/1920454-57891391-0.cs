    public class SomeClass<T, U>
        where T : IFoo
        where U : IBar
    {
        public void SomeMethod(T t) { /* ... */ }
    }
