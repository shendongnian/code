    public static class Extensions
    {
        public static T[] ReplaceEvery<T>(this T[] values, int every, T replacement)
        {
            return values.Select( (x,i) => (((i+1)%every) == 0) ? replacement : x).ToArray();
        }
    }
