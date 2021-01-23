    public class myDataObject //The data object you already have.
    {
        public string UserID;
        public string value2;
        private PhoneUser _User; 
    	public PhoneUser User
    	{
    		get
    		{
    			if(_User==null)
    				_User = getUserFromDatabase(UserID);
    			return _User;
    		}
    	}
    }
