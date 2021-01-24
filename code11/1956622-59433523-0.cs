    public class CustomerValidator : AbstractValidator<Customer> {
      public CustomerValidator() {
        RuleFor(x => x.Surname).NotEmpty();
        RuleFor(x => x.UserIDNumber).NotEmpty().WithMessage("Enter a valid number for UserIDNumber");
        RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
        RuleFor(x => x.Address).Length(20, 250);
        RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
      }
