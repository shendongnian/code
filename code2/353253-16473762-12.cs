        public class Quote
        {
        	...
        	public DateTime DateCreated
        	{
        		get { return CRM.Global.ToLocalTime(_DateCreated); }
        		set { _DateCreated = value.ToUniversalTime(); }
        	}
        	private DateTime _DateCreated { get; set; }
        	...
        }
