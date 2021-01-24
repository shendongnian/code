    public class A<T> where T : class
    {
        public void Foo(T input) where T : SomeBaseClass // additional constraints for generic type on class level
        {
    
        }
    }
