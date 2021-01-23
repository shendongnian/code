    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class EndDateAttribute : ValidationAttribute
    {
        public EndDateAttribute(DateTime endDate)
        {
            EndDate = endDate;
        }
        
        public DateTime EndDate { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            DateTime val;
            try
            {
                val = (DateTime)value;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            if (val >= EndDate)
                return false;
            return true;
        }
    }
