    public static class EnumHelper<T>
    {
        public static IEnumerable<(int eCode, T eType)> GetListItem()
        {
            var enums = new List<(int eCode, T eType)>();
            foreach (var item in (T[])Enum.GetValues(typeof(T)))
            {
                enums.Add((Convert.ToInt32(item), item));
            }
            return enums;
        }
    }
