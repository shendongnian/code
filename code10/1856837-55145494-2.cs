    public class Users
    {
    	public class TestConsumer
    	{
    		public string id
    		{
    			get;
    		}
    
    		= "XXXXXXXX";
    	}
    }
    
    
    public class Uri
    {
    	protected Users.TestConsumer testConsumer;
    	private Context Context;
    	public Uri(Context context)
    	{
    		Context = context;
    		testConsumer = new Users.TestConsumer();
    	}
    }
    
    public class RegisterUri : Uri
    {
    	public RegisterUri(Context context): base (context)
    	{
    	}
    
    	public string RegApplicantInfo1
    	{
    		get
    		{
    			return $"/v1/consumer/applications/{testConsumer.id}/register-applicant-contact-information";
    		}
    	}
    }
