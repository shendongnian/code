    public class LocaleDescriptionAttribute : DescriptionAttribute
    {
        ...
        public LocaleDescriptionAttribute(string resourceKey, Type resourceType)
            : base(resourceKey)
        {
            this.resourceType = resourceType;
        }
    
        public override string  Description
        {
    	    get 
    	    { 
                var description = base.Description;
                PropertyInfo property = resourceType.GetProperty(
                           description, BindingFlags.Public | BindingFlags.Static);
                if (property == null)
                {
                    return description;
                }
                return property.GetValue(null, null) as string;
    	    }
        }    
    }
