    public class Class1 
    {
        public bool ImportantInformation {get; set;}
        [ConditionallyValidatedAttribute] //-->Validation Attribute here
        public Class2 A {get; set;}
        public Class3 B {get; set;}
    }
    public class Class2 
    {
        public string X {get; set;}
    }  
    public sealed class ConditionallyValidatedAttribute : ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext vc) 
        {
            var importantInformation = bool.Parse(vc.ObjectType.GetProperty("ImportantInformation")?.GetValue(vc.ObjectInstance)?.ToString() ?? "false");
            if (importantInformation && (!(value is Class2) || string.IsNullOrEmpty(((Class2)value).X)))
            {
                return new ValidationResult($"{vc.MemberName} is invalid");
            }
            
            return ValidationResult.Success;
        }
    }
