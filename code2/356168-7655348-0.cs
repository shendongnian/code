    [AttributeUsage(AttributeTargets.Class)]
    class CodeAttribute : Attribute
    {
    	public CodeAttribute(string code)
    	{
    		Code = code;
    	}
    	
    	public string Code { get; private set; }
    }
