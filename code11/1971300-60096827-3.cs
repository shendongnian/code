    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class StringRangeAttribute : ValidationAttribute
    {       
        public string[] AllowableValues { get; set; }
       
        public override bool IsValid(object value)
        {
            string actualValue = value as string;
            if (AllowableValues?.Contains(actualValue) == true)
            {
                return true;
            }
            return false;
        }
    }
