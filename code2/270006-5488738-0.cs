    public static class Extensions
    {
        public static TDest? ConvertTo<TSource, TDest>(this TSource? source) 
            where TDest: struct 
            where TSource: struct
        {
            if (source == null)
            {
                return null;
            }
            return (TDest)Convert.ChangeType(source.Value, typeof(TDest));
        }
    }
