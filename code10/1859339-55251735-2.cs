    public static class RequiredItemListExtensions
    {
        public static void Add(this List<RequiredItem> list, string pattern, double req)
        {
            list.Add(new RequiredItem(pattern, req));
        }
    }
