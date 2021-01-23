    public interface IProvider
    {
        IResult<T> Request<T>(IQuery request);
    
        DataSourceDescriptor DataSource { get; set; }
    
        IConfiguration Configuration { get; set; }
    
        IResult Request(IQuery request);
    }
