    public sealed class DateBetweenAttribute : ValidationAttribute
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public override bool IsValid(object value)
        {
            DateTime start = DateTime.Parse(StartDate);
            DateTime end = DateTime.Parse(EndDate);
    
            DateTime date = (DateTime)value;
    
            // Do you own validation logic here.
            return (date > start) && (date < end);            
        }
    }
