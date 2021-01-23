    public class EnumList
    {
        public static IEnumerable<KeyValuePair<int, string>> Of<T>()
        {
            return Enum.GetValues(typeof (T))
                .Cast<T>()
                .Select(p => new KeyValuePair<int, string>(Convert.ToInt32(p), p.ToString()))
                .ToList();
        }
    }
