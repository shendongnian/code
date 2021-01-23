    public interface IServiceWrapper<T> 
    {     
      public int StatusCode {get;set}     
      public string StatusMessage {get;set;}     
      public List<T> ReturnedData {get;set;} 
    } 
