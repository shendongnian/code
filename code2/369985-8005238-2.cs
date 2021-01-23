    public static class IDatedExtensions
    {
        public static IEnumerable<T> HasDate(IEnumerable<T> objects)
            where T : IDated
        {
            foreach (var obj in objects)
            {
                if ((obj != null) && (obj.Date.HasValue))
                    yield return obj;
            }
        }
    }
