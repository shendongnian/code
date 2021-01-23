    public partial class Apple : IValidatableObject // Assume the Apple class has an IList<Color> property called AvailableColors
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var color in this.AvailableColors)
            {
                if (color.Name == "Blue") // No blue apples, ever!
                {
                    yield return new ValidationResult("You cannot have blue apples.");
                }
            }
        }
    }
