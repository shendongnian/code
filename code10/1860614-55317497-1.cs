    // Base class
    public class BaseEmployeeMap<T> : ClassMap<T> where T : Employee
    {
        public BaseEmployeeMap()
        {
            Map(p => p.Name);
            // add all Properties that are common to both Employee and EmployeeTemp
        }
    } 
    // Mapping for Employee
    public class EmployeeMap : BaseEmployeeMap<Employee>
    {
        public EmployeeMap() : base()
        {
            EntityName("Employee");
        }
    } 
    // Mapping for EmployeeTemp
    public class EmployeeTempMap : BaseEmployeeMap<Employee>
    {
        public EmployeeTempMap() : base()
        {
            EntityName("EmployeeTemp");
        }
    } 
