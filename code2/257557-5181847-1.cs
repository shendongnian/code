    // use a custom type converter.
    // it can be set on an interface so we don't have to redefine it for all deriving classes
    [TypeConverter(typeof(BenchmarkTypeConverter))]
    public interface IBenchmark
    {
        string ID { get; set; }
        Type Type { get; set; }
        string Name { get; set; }
    }
