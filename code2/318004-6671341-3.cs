    public abstract class ConfigSection<T>
    {
        public static Dictionary<String, T> LoadSection(string sectionName)
        {
            ...
            //builds but does not always do what I want
            ret.Add((String)entry.Key,
                    (T)Convert.ChangeType((string)entry.Value, typeof(T)));
            ...
        }
    }
