    public class ISessionExtensions
    {
        public static IEmployeeRepository GetEmployeeRepository( this ISession session )
        {
             return new EmployeeRepository(session);
        }
    }
    
    public class EmployeeRepository()
    {
        internal EmployeeRepository( ISession s )
        {
        }
    
        public IEnumerable<Employee> GetEmployeesFromDepartment( Department d )
        {
          ...
        }
    }
