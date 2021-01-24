    public class Bar
    {
        public string Foo { get; set; }
        public Foo? FooEnum { get; set; }
    }
    ...
    var result = JsonSerializer.Deserialize<Bar>(jsonSpan, options);
    Enum.TryParse<Foo>(result, out Bar.FooEnum);
