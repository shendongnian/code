       [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
       public class NotABananaAttribute : ValidationAttribute
       {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            var isValid = true;
    
            if (!string.IsNullOrEmpty(inputValue))
            {
                isValid = inputValue.ToUpperInvariant() != "BANANA";
            }
    
            return isValid;
        }
       }
