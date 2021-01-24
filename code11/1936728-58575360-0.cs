    public class L : List<object> { }
    public class D : Dictionary<string, object> { }
    var candidates = new D
    {
        ["name"] = new L
        {
            new L
            {
                new D
                {
                    ["tag"] = "id",
                    ["pattern"] = "(.+)"
                }
            }
        }
    };
