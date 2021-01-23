    public class Foo<T> where T: ICloneable
    {
        public T Clone(T what)
        {
            if (what is RunProperties)
                return (T)what.Clone();
            ...
        }
    }
