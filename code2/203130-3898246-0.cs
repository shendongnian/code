    public class ServiceCodes {
    	
    	public static readonly ServiceCodes Transfer = new ServiceCodes(Convert.ToInt32(ConfigurationManager.AppSettings["servTransfer"]));
    	public static readonly ServiceCodes ChangePlate = new ServiceCodes(Convert.ToInt32(ConfigurationManager.AppSettings["servChangePlate"]));
    	
    	internal int Code {get; private set;}
    	
    	private ServiceCodes(int code) {
    		Code = code;
    	}
    }
