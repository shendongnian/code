    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty();
            RuleFor(x => x.PostalCode)
                .NotEmpty();
            RuleFor(x => x.Street)
                .NotEmpty();
        }
    }
    
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.FirstAddress)
                .SetValidator(new AddressValidator());
            RuleFor(x => x.SecondAddress)
                .SetValidator(new AddressValidator())
                .When(x => x.RequireSecondAddress);
        }
    }
