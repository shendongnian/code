    public class PinValidator : AbstractValidator<PinModel>
        {
            public PinValidator()
            {
                RuleFor(p => p.Pin).NotNull().Matches("^[0-9]{4}$");
                RuleFor(p => p).Must(PinsAreSame)
                    .WithMessage("PINs must be the same");
            }
    
            private bool PinsAreSame(PinModel pinModel)
            {
                return (pinModel.Pin.Equals(pinModel.PinConfirmation));
            }
        }
