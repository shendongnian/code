    //add the attribute here
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Foo
    {
        A = 1,
        B = 2
    }
    
    public class Bar
    {
        public Foo? Foo { get; set; }
    }
    public static void Main()
    {
        var jsonString = "{\"foo\": \"C\"}";
    
        try
        {
            // use newtonsoft json converter
            var result = JsonConvert.DeserializeObject<Bar>(jsonString);
            Console.WriteLine(result.Foo == null);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Serialization Failed" + ex.Message);
        }
    }
