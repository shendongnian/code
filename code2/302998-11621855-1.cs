    [DataContract]
    public abstract class Bar
    {
    }
    [DataContract]
    public class Foo : Bar
    {
        string one { get; set; }
        string two { get; set; }
        string three { get; set; }
    }
