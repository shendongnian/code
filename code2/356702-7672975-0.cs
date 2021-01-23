    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DateFormatAttribute : ValidationAttribute
    {
        private string _format;
    
        public DateFormatAttribute(string format) 
            : base("Date is not in correct format.")
        {
            _format = format;
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(DateTime))
                {
                    var valid = DateTime.TryParseExact(value.ToString(), format, CultureInfo.InvariantCulture);
                    return valid;
                }
                else
                {
                    return false;   
                }
            }
            return true;
        }
    }
