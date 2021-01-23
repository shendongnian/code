    public static class CrazyExtension
    {
        public S Project<T,S>(this T value, Func<T,S> Selector)
        {
            return Selector(value);
        }
    }
