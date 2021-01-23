    // The Base class
    public class Employee
    {
    	public int EmployeeId { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public DateTime DateOfJoining { get; set; }
    }
  
    // The derived class
    public class Manager : Employee
	{
		public IList<Employee> EmployeesReporting { get; set; }
	}
    
