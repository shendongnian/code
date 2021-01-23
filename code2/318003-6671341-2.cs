    public abstract class ConfigSectionBase<T>
    {
        public static Dictionary<String, T> LoadSection(string sectionName)
        {
            ...
            //builds but does not always do what I want
            ret.Add((String)entry.Key, Convert((string)entry.Value));
            ...
        }
        abstract T Convert(string v);
    }
    public class IntConfigSection: ConfigSectionBase<int>
    {
        override int Convert(string v)
        {
            return int.Parse(v);
        }
    }
    public class StringConfigSection: ConfigSectionBase<string>
    {
        override string Convert(string v)
        {
            return v;
        }
    }
