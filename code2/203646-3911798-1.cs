    static class Utility<T, TReturn>
    {
        static TReturn Change(T arg)
        {
            return (TReturn) System.ComponentModel.TypeDescriptor.GetConverter(typeof(T)).ConvertTo(arg, typeof(TReturn));
        }
    }
