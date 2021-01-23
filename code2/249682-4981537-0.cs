    interface IHostProvider
    {
      void Get<T> (out T result) where T : IHost,  new();
    }
    
    public interface IHost
    {
    }
    
    public class Something : IHost
    {
    }
    
    public class Provider : IHostProvider
    {
      public void Get<T> (out T result) where T: IHost, new()
    	{
    	  result = new T();
    	}
    }
