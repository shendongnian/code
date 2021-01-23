    public static class ObjectExtensions
    {
        public static string Extract<T>(this T theObject)
        {
            return string.Join(
                ",",
                new List<string>(
                    from prop in theObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    where prop.CanRead
                    select string.Format("{0} = {1}",
                    prop.Name,
                    prop.GetValue(theObject, null))).ToArray());
        }
    }
