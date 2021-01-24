    public class BaseModelValidator : AbstractValidator<BaseModel>
    {
        public BaseModelValidator()
        {
            RuleFor(o => o.Name).Length(1, 20);
        }
    }
    public class DerivedModelValidator : AbstractValidator<DerivedModel>
    {
        public DerivedModelValidator(BaseModelValidator baseValidator)
        {
            RuleFor(o => o).SetValidator(baseValidator);
            RuleFor(o => o.Age).GreaterThanOrEqualTo(0);
        }
    }
