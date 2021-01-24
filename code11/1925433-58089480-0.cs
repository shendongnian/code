    public class CallWebService<T> // don't forget to inherit IDisposal.
    {
    	
    	private WebServiceWRGClient Client {get; set;}
    	
    	private BasicHttpBinding HttpBinding {get; set;}
    	
    	private EndpointAddress  Endpoint {get; set;}
    	
    	private ChannelFactory Channel {get; set;}
    
    	// if needed outside this class, make it public to be accessed globally. 
    	private User UserAccount {get; set;}
    	
    	public CallWebService<T>(string url)
    	{
    		Client  	= new WebServiceWRGClient(); 
    		
    		//See which Binding is the default and use it in this constructor. 
    		HttpBinding	= new BasicHttpBinding(BasicHttpSecurityMode.Transport);
    		
    		Endpoint	= new EndpointAddress(url); 
    		
    		// T is generic, WebServiceWRG in this example 
    		Channel 	= new ChannelFactory<T>(HttpBinding, Endpoint).CreateChannel();
    		
    		UserAccount	= new User();
    	}
    	
    	// another constructor with BasicHttpBinding
    	public CallWebService<T>(string url, BasicHttpSecurityMode securityMode)
    	{
    		Client  	= new WebServiceWRGClient(); 
    		
    		//See which Binding is the default and use it in this constructor. 
    		HttpBinding	= new BasicHttpBinding(securityMode);
    		
    		Endpoint	= new EndpointAddress(url); 
    		
    		// T is generic, WebServiceWRG in this example 
    		Channel 	= new ChannelFactory<T>(HttpBinding, Endpoint).CreateChannel();
    		
    		UserAccount	= new User();
    		
    	}
    	
    	// Change this method to return the response. Task<Response> is just a placeholder for this example 
    	public async Task<Response> Call(string userName, string password)
    	{
    		UserAccount.UserName = await Channel.EncryptValueAsync(userName);
    		
    		UserAccount.Password = await Channel.EncryptValueAsync(password);
    		
    		var response = await Client.ClaimSearchAsync(User, "", "", 12345, statuscode.NotSet, "");		
    	}
    	
    	/*
    		[To-Do] : gather all other releated methods into this class, then try to simplify them. 
    	
    	*/
    	
    }
