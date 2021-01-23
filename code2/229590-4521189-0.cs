    public class MyProxy<T> : RealProxy
    {
        public MyProxy()
            : base(typeof(T))    // this was missing
        {
            ...
        }
        
        ...
    }
