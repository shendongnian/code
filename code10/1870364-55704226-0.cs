    public static class MyExtensions
    {
        public static void AddElement(this IDictionary container, string key, string value)
        {
            container.Add(key, value);
        }
    }
