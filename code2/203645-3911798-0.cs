    static class Utility<T, TReturn>
    {
        static TReturn Change(T arg, Converter<TReturn, T> convert)
        {
            System.Diagnostics.Debug.Assert(arg != null);
            return convert(arg);
        }
    }
