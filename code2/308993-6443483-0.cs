    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CustomAttribute : ValidationAttribute
    {
    	public override bool IsValid(object value)
    	{
    		IPAddressAttribute a1 = new	IPAddressAttribute();
    		DomainNameAttribute a2 = new DomainNameAttribute();
    		return a1.IsValid(value) || a2.IsValid(value);
    	}    
    }
