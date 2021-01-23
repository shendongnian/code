    public struct WrappedEnumerator<T>
    {
        T myEnumerator;
        public T GetEnumerator() { return myEnumerator; }
        public WrappedEnumerator(T theEnumerator) { myEnumerator = theEnumerator; }
    }
    public static class AsForEachHelper
    {
        static public WrappedEnumerator<IEnumerator<T>> AsForEach<T>(this IEnumerator<T> theEnumerator) {return new WrappedEnumerator<IEnumerator<T>>(theEnumerator);}
        static public WrappedEnumerator<System.Collections.IEnumerator> AsForEach(this System.Collections.IEnumerator theEnumerator) 
            { return new WrappedEnumerator<System.Collections.IEnumerator>(theEnumerator); }
    }
