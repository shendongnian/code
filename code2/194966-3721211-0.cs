    [AttributeUsage(AttributeTargets.Class)]
    public class RatingValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = (MyModel)value;
            // TODO: here you have the model so work with the 
            // Rating and Heading properties to perform your 
            // validation logic
            return true;
        }
    }
