    public partial class Email
    {
    	public EmailEnums.EmailPriorityEnum EmailPriority
    	{
    		get { return (EmailEnums.EmailPriorityEnum)Priority; }
    		set { Priority = (int)value; }
    	}
    }
