    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void  HelloWorld();
    }
    
    public class Service : IService
    {
    	public void HelloWorld()
    	{
    		//Hello World
    	}
    }
