    public class EmployeeRepository : IRepository<Employee> {
        public IQueryable<Employee> Select() {
            return this.ObjectContext.Employees;
        }
    }
