    public void Test()
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.SetupExtensions();
    
        ObjectWithDefaultValue obj = new ObjectWithDefaultValue
        {
            Id = 13,
            FirstName = "foo",
            LastName = "bar",
            Age = 12
        };
    
        string json = JsonSerializer.Serialize(obj, options); // {"Id":13,"LastName":"bar"}
    }
