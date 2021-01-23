    public static class DisposableExtensions
    {
        public static DisposableWrapper<T> Wrap<T>(this T instance)
        {
            return new DisposableWrapper<T>(instance);
        }
    }
