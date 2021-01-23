    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateString = value as string;
            if (dateString == null || string.IsNullOrWhiteSpace(dateString))
            {
                return true; // Not our problem
            }
            DateTime result;
            var success = DateTime.TryParse(dateString, out result);
            return success;
        }
