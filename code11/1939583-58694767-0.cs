    public static class Extensions
    {
        public static IEnumerable<T> WithId<T>(this IEnumerable<T> source, string id) where T: IMyString
        {
            return source.Where(x => x.Id == id);
        }
    }
