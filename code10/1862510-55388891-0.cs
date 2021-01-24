    public abstract class CommonModelValidator<T> : AbstractValidator<T> where T : BaseModel
    {
        protected CommonModelValidator()
        {
            RuleFor(o => o.Name).Length(1, 20);
        }
    }
    public class BaseModelValidator : CommonModelValidator<BaseModel>
    {
    }
    public class DerivedModelValidator : CommonModelValidator<DerivedModel>
    {
        public DerivedModelValidator(BaseModelValidator baseValidator) 
            : base()
        {
            RuleFor(o => o.Age).GreaterThanOrEqualTo(0);
        }
    }
