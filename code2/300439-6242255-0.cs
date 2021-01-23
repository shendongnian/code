    public interface ISetting { }
    public class Setting<T> : ISetting
    {
        // ...
    }
    // example usage:
    IList<ISetting> list = new List<ISetting>
    {
        new Setting<int> { name = "foo", value = 2 },
        new Setting<string> { name = "bar", value "baz" },
    };
