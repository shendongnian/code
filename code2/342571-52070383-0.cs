    public class MyConfig
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
    }
    var config = new MapperConfiguration(cfg => {});
    var mapper = config.CreateMapper();
    
    var source = new Dictionary<string, object>
    {
        ["Foo"] = "Hello",
        ["Bar"] = 123
    };
    var obj = mapper.Map<MyConfig>(source);
    obj.Foo == "Hello"; // true
