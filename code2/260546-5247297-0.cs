    public interface IProvider
    {
        DataSourceDescriptor DataSource { get; set; }
    
        IConfiguration Configuration { get; set; }
    
        IResult Request(IQuery request);
    
        IResult<T> Request<T>(IQuery request);
    }
