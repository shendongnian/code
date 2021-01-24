    public enum Foo
    {
        A = 1,
        B = 2,
        // what ever name and enum number that fits your logic
        Unknown = 99
    }
    
    public class Bar
    {
        public Foo? Foo { get; set; }
    }   
    
    public static void Main()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new CustomEnumConverter());
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    
        var jsonString = "{\"foo\": \"C\"}";
        var jsonSpan = (ReadOnlySpan<byte>)Encoding.UTF8.GetBytes(jsonString);
    
        try
        {
            var result = JsonSerializer.Deserialize<Bar>(jsonSpan, options);
    
            if (result.Foo == Foo.Unknown)
                result.Foo = null;
    
            Console.WriteLine(result.Foo == null);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Serialization Failed" + ex.Message);
        }
    }
