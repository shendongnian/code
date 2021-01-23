    public class Repository
    {
        public Repository(string connectionString)
        {
            // ...
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return GetEmployeesFromDb();
        }
        public Employee GetEmployeeById(Guid id)
        {
            // ...
        }
        public void StoreEmployee(Employee employee)
        {
            // ...
        }
        // etc.
    }
