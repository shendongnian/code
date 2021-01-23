    static class ItemsExtensions
    {
        private static readonly IEnumerable<Items> empty = Enumerable.Empty<Items>();
        public static IEnumerable<Items> GetFlags(this Items items)
        {
            ulong bits = (ulong)items;
            var values = Enum.GetValues(typeof(Items)) as Items[];
            List<Items> results = new List<Items>();
            for (int i = values.Length - 1; i >= 0; i--)
            {
                uint mask = (uint)values[i];
                if (i == 0 && mask == 0L)
                    break;
                if ((bits & mask) == mask)
                {
                    results.Add(values[i]);
                    bits -= mask;
                }
            }
            if (bits != 0L)
                return empty;
            if (items != 0L)
                return results;
            if (bits == (ulong)items && values.Length > 0 && values[0] == 0L)
                return values.Take(1);
            return empty;
        }
    }
