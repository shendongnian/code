    public class PermittedYearRangeAttribute : RangeAttribute
    {
        public PermittedYearRangeAttribute()
            : base(1900, DateTime.Now.AddYears(-50).Year)
        {
            ErrorMessage = string.Format("Year must be between 1900 and {0}", DateTime.Now.AddYears(-50).Year);
        }
    }
