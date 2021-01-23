    [AttributeUsage(AttributeTargets.Class)]
    public class EitherPropertyRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // value will be the model
            Address address = (Address)value;
            // TODO: Check the properties of address here and return true or false
            return true;
        }
    }
