    class Customer {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
    }
    interface IValidator<T> {
        bool Validate(T t);
    }
    class CustomerValidator : IValidator<Customer> {
        public bool Validate(Customer t) {
            // validation logic
        }
    }
