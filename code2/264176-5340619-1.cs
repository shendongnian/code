    public interface IValidator<T>
    {
        bool IsValid(T objectToInspect);
    }
    public class Employee
    {
        private readonly IValidator<Employee> validator;
        public Employee(IValidator<Employee> validator)
        {
            this.validator = validator;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsValid()
        {
            return validator.IsValid(this);
        }
    }
