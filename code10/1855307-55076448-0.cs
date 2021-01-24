    public class MyOptions
    {
        public string MyValue { get; set; }
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        var options = Configuration.GetSection("MyOptions").Get<MyOptions>();
        if (string.IsNullOrWhiteSpace(options?.MyValue))
        {
            throw new ApplicationException("MyValue is not configured!");
        }
    }
