    public static class Extensions
    {
        public static void AddWithSession<T>(this List<T> list, T value, string key)
        {
            list.Add(value);
            HttpContext.Current.Session[key] = list;
        }
    }
    str.AddWithSession(accordion.ID,SessionKeys.QueryFillOrder);
