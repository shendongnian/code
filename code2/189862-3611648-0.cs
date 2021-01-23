    public class RequireEitherAttribute : ValidationAttribute
    {
        private string firstProperty;
        private string secondProperty;
        public RequireEitherAttribute(string firstProperty, string secondProperty)
        {
            this.firstProperty = firstProperty;
            this.secondProperty = secondProperty;
        }
        public override bool IsValid(object value)
        {
            object firstValue = value.GetType().GetProperty(firstProperty).GetValue(value, null);
            object secondValue = value.GetType().GetProperty(secondProperty).GetValue(value, null);
            if (firstValue != null)
            {
                return true;
            }
            if (secondValue != null)
            {
                return true;
            }
            // neither was supplied so it's not valid
            return false;
        }
    }
