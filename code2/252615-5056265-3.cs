    public class User {
    	
    	public string UserName { get; set; }
    	
    	public Address UserAddress { get; set; }
    	
    	public UserStreet {
    		get { return UserAddress != null ? UserAddress.Street : ""; } 
    	}
    }
