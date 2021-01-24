        public class Customer
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
    public class CustomerCriticalValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotNull().Length(5, 100);
            RuleFor(customer => customer.LastName).NotNull().Length(5, 100);
        }
    }
    public class CustomerWarningValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
         
            RuleFor(customer => customer.MiddleName).Length(5, 100).When(c => string.IsNullOrWhiteSpace(c.MiddleName));
        }
    }
