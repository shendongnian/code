    using System;
    using System.ComponentModel.DataAnnotations;
    
    namespace MyDataAnnotations
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class IntegerAttribute : DataTypeAttribute
        {
            public IntegerAttribute()
                : base("integer")
            {
            }
    
            public override string FormatErrorMessage(string name)
            {
                if (ErrorMessage == null && ErrorMessageResourceName == null)
                {
                    ErrorMessage = "Enter an integer"; // default message
                }
    
                return base.FormatErrorMessage(name);
            }
    
            public override bool IsValid(object value)
            {
                if (value == null) return true;
    
                int retNum;
    
                return int.TryParse(Convert.ToString(value), out retNum);
            }
        }
    }
