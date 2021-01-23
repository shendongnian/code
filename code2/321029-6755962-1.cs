    public class Employee
    {
        public FirstName { get; set; }
        public LastName { get; set; }
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    public static class EmployeeFactory
    {
        public static IEnumerable<Employee> GetEmployeesNamedSmith(IObjectContainer db)
        {
            var employees = from Employee e in db
                            where e.LastName.Equals("Smith")
                            select e;
            foreach (var emp in employees)
            {
                yield return emp;
            }
        }
    }
