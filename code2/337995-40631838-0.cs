    public class IsNotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            var valueType = value.GetType();
            var emptyField = valueType.GetField("Empty");
            if (emptyField == null) return true;
            var emptyValue = emptyField.GetValue(null);
            return !value.Equals(emptyValue);
        
        }
    }
