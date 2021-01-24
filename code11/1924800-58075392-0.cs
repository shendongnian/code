    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotNull().Length(5, 100);
            RuleFor(customer => customer.LastName).NotNull().Length(5, 100).OnAnyFailure((customer) => 
            {
                customer.LastName = null;
                customer.Warnings.Add(nameof(customer.LastName));
            });
            RuleFor(customer => customer.MiddleName).Length(5, 100).When(c => string.IsNullOrWhiteSpace(c.MiddleName));
        }
    }
