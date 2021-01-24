    public class ModelValidator : AbstractValidator<MyModel>
    {
        public ModelValidator()
        {
            RuleFor(x => x.StartDate)
                .WithMessage("Invalid start date");
        }
    }
