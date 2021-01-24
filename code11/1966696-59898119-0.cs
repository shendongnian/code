    public class ServiceSpe : IServiceSpe
    {
        public string GetLabel()
        {
            return "hello world";
        }
    }
In my common project :
    public interface IServiceSpe
    {
        string GetLabel();
    }
In my controller :
    public MyController()
	{
	}
	public MyController(IServiceSpe serviceSpe)
	{
		if (serviceSpe != null)
		{
			string result = serviceSpe.GetLabel();
		}
	}
If dependency contains class with interface "IServiceSpe" :
MyController(IServiceSpe serviceSpe) is called 
else 
MyController() is called
