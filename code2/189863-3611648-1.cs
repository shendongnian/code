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
            return InputSupplied(firstValue) || InputSupplied(secondValue);
        }
        private bool InputSupplied(object obj)
        {
            if (obj == null)
                return false;
            if (obj is string)
            {
                string str = (string)obj;
                if (str.Trim() == string.Empty)
                    return false;
            }
            return true;
        }
    }
