    public class RequireEither : ValidationAttribute
    {
        private string firstProperty;
        private string secondProperty;
    
        public RequireEither(string firstProperty, string secondProperty)
        {
            this.firstProperty = firstProperty;
            this.secondProperty = secondProperty;
        }
    
        public override bool IsValid(object value)
        {
            var firstValue = value.GetType().GetProperty(this.firstProperty).GetValue(value, null) as string;
            var secondValue = value.GetType().GetProperty(this.secondProperty).GetValue(value, null) as string;
    
            if (!string.IsNullOrWhiteSpace(firstValue))
            {
                return true;
            }
    
            if (!string.IsNullOrWhiteSpace(secondValue))
    	    {
                return true;
    	    }
            // neither was supplied so it's not valid
            return false;
        }
    }
