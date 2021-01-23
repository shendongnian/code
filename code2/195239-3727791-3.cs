    namespace YourNamespace
    {
        partial class Employee
        {
            public static List<Employee> GetListOfEmployees()
            {
                //DATA ACCESS
                var emps = GetEmployeesFromDb(); // fetch from db
                return emps;
            }
        }        
    }
