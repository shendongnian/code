Dictionary<string, string> dict = new Dictionary<string, string>
{
        { "Config0", "0" },
        { "Config1", "1" },
        { "AnotherKey", "2" },
        { "SomeOtherKey", "3" }
};
Dictionary<string, string> configOnlyDictionary = dict.Where(x => x.Key.Contains("Config")).ToDictionary(x => x.Key, x => x.Value);
