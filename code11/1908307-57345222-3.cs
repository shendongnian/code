    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CommandPrefixAttribute:Attribute
    {
    	public string Prefix {get;set;}
    	public CommandPrefixAttribute(string prefix)
    	{
    		Prefix = prefix;
    	}
    }
