    public class YourModelValidator: AbstractValidator<YourModel>
    {
        public YourModelValidator(IHttpContextAccessor httpContext)
        {
            RuleFor(x => x.YourProprty).Custom( (html, context) =>
            {
                var user = httpContext.User;
                if (!user.HasClaim(c => c.Type.Equals(claim))
                {
                    context.AddFailure("Claim is missing.");
                }
            });
        }
    }
