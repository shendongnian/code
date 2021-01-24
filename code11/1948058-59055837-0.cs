    public class A<T> where T : class
    {
        public void Foo<U>(U input) where U : T, SomeBaseClass, SomeInterface //whatever
        {
    
        }
    }
