    using System;
    using ImpromptuInterface.Dynamic;
    public abstract class Dispatcher<T>
    {
        protected CacheableInvocation _cachedDynamicInvoke;
    
        protected Dispatcher()
        {
            _cachedDynamicInvoke= new CacheableInvocation(InvocationKind.InvokeMember, "CallDispatch", argCount: 1, context: this);
        }
    
        public T Call(object foo)
        {
            return (T) _cachedDynamicInvoke.Invoke(this, foo);
        }
    
        protected abstract T CallDispatch(int foo);
        protected abstract T CallDispatch(string foo);
    }
    
