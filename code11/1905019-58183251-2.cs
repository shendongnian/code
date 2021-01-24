    public class ModelValidator : AbstractValidator<Model>
	{
		public ModelValidator()
		{
			RuleFor(x => x.Emails)
				.NotNull()
				.ForEach(x =>
				{
					x.SetValidator(y => new InlineValidator<string>()
					{
						z => z.RuleFor(u => u)
						.EmailAddress()
						.AddMessagePrefix()
					});
				});
		}
	}
