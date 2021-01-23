    using System;
    public abstract class Base<T> where T : Base<T> {
        public T FluentMethod() {
            return (T)(this);
        }
    }
    public class Derived : Base<Derived> {
    }
    public class SomeClass {
        Base<T> GetItem<T>() where T : Base<T> {
            throw new NotImplementedException();
        }
    }
