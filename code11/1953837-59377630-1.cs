    public interface IServiceFactory
    {
    	IService Get(MyObject myObject);
    }
    
    public class ServiceFactory : IServiceFactory
    {
    	private readonly IServiceProvider sp;
    
    	public ServiceFactory(IServiceProvider sp)
    	{
    		this.sp = sp;
    	}
    
    	public IService Get(MyObject myObject)
    	{
    		if(myObject.SomeProperty == "whatever")
    		{
    			return ActivatorUtilities.CreateInstance<ServiceOne>(this.sp);
    		}
    		else
    		{			
    			return ActivatorUtilities.CreateInstance<ServiceTwo>(this.sp);
    		}
    	}
    }
