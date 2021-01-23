    using System;
    
    public abstract class Dispatcher<T>
    {
        public T Call(int foo) { return CallDispatch(foo); }
        public T Call(string foo) { return CallDispatch(foo); }
    
        protected abstract T CallDispatch(int foo);
        protected abstract T CallDispatch(string foo);
    }
