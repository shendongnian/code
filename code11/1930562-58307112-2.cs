    public class myObject : IValidatable
    {
        public CustomEnum myEnum { get; set; }
        public void Validate()
        {
            //Do your validation here
            Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
        }
    }
