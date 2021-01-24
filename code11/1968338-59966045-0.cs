    static void Main(string[] args)
    {
        List<string> values = new List<string>();
        values.Add("12.0.1");
        values.Add("12.2");
    
        string value = "12";
    
        var isExists = values.Any(x => x.StartsWith($"{value}."));
    }
