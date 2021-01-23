    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    sealed class MemberBindingAttribute : Attribute
    {
    	readonly string memberName;
    
    	public MemberBindingAttribute(string memberName)
    	{
    		this.memberName = memberName;
    	}
    
    	public string MemberName
    	{
    		get { return memberName; }
    	}
    }
    
    enum eType
    {
        [MemberBinding("a")]
        A,
        [MemberBinding("b")]
        B
    }
