    public class Fragile<T>
    {
        public Fragile(Func<T> valueFactory, Func<T, bool> isStillValid)
        {
            //...
        }
        public T Value { get /* TODO */ ; }
    }
