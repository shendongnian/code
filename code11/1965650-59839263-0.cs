    public interface IConfiguration
    {
        string Url { get; }
    
        string Password { get; }
    }
    public interface IPersonConfiguration : IConfiguration {}
    public interface IProductConfiguration : IConfiguration {}
    public interface IOrderConfiguration : IConfiguration {}
