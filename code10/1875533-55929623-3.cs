    public class ModelValidator : AbstractValidator<Model>
    {
    	public ModelValidator()
    	{
            // add a rule that Date must be in the past, shouldn't be empty
            // and in the correct format
    		RuleFor(model => model.PublishedAt)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .Must(date => !string.IsNullOrWhiteSpace(date))
                   .WithMessage("PublishAt is a required parameter")
               .Must(arg =>
               {
                   if (DateTime.TryParseExact(arg.ToString(), new[] { "dd-MMM-yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                   {
                       return date < DateTime.Now;
                   }
                   return false;
                })
                .When(model => !string.IsNullOrWhiteSpace(model.PublishedAt))
                .WithMessage("Argument PublishAt is invalid. Please specify the date in dd-MMM-yyy and should be in the past");
    	}
    }
