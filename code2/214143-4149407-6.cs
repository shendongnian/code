    public class EmployeeSpecification : ISpecification<Employee> {
        public bool IsSatisfiedBy(Employee entity) {
            Contract.Requires<ArgumentNullException>(entity != null);
            return !String.IsNullOrWhiteSpace(entity.FirstName) &&
                   !String.IsNullOrWhiteSpace(entity.LastName);
        }
    }
