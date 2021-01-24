    public class MyModelValidator: AbstractValidator<SomeDto>
        {
            public MyModelValidator()
            {
                RuleFor(x => x.Id)
                    .Empty()
                    .WithMessage(DefaultMessages.InvalidInput);
    
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage(DefaultMessages.InvalidName)
                    .Length(2, 80)
                    .WithMessage(DefaultMessages.InvalidName);
            }
        }
