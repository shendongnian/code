    public static class ExtensionMethods
    {
        public static Lazy<U> Convert<T,U>(this Lazy<T> source, Func<Lazy<T>, Lazy<U>> convert)
        {
            return convert(source);
        }
    }
    Lazy<List<int>> source = new Lazy<List<int>>();
    Lazy<List<string>> converted = source.Convert(x => 
    { 
     return new Lazy<List<string>>()
                {
                    Items = x.Items.ConvertAll<string>(i => i.ToString())
                };
    });
