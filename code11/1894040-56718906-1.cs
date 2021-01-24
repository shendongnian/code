    public class GetApplicationQueryValidator : AbstractValidator<GetApplicationQuery> {
        public GetApplicationQueryValidator() { 
            RuleFor(m => m.Name).MinimumLength(30).WithMessage("Name must be greater than 30 characters, long");
        }
    }
