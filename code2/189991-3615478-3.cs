    public sealed class DateStartAttribute : ValidationAttribute
        {        
            public override bool IsValid(object value)
            {
                DateTime dateStart = (DateTime)value;
                // Meeting must start in the future time.
                return (dateStart > DateTime.Now);
            }
        }
    
        public sealed class DateEndAttribute : ValidationAttribute
        {
            public string DateStartProperty { get; set; }
            public override bool IsValid(object value)
            {
                // Get Value of the DateStart property
                string dateStartString = HttpContext.Current.Request[DateStartProperty];
                DateTime dateEnd = (DateTime)value;
                DateTime dateStart = DateTime.Parse(dateStartString);
    
                // Meeting start time must be before the end time
                return dateStart < dateEnd;
            }
        }
