    public class Employee
    {
    	public Guid EmployeeId { get; set; }
    	public string Name { get; set; }
    	//This is the FK from Access entitie
    	public int AccessId { get; set; }
    	//This is the referente to use with the EF Lazy Loading
    	public virtual Access Access { get; set; }
    }
