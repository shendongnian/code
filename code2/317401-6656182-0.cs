    public interface IEmployeeRoleSpecification<in TRole> : IRoleSpecification<EmployeeEx, EmployeeRole> where TRole : EmployeeRole
    {
    	 bool IsJobRole { get; set; }
    }
    
    public abstract class EmployeeRoleSpecification<TRole> : IEmployeeRoleSpecification<TRole> 
    	where TRole : EmployeeRole
    {
    
    	public virtual bool CanAddRoleFor(EmployeeEx employee) { return false; }
    
    	public virtual void OnPreInsert(EmployeeEx instance, EmployeeRole newRole) {
    		// jobRole helps enforce role constraints
    		// employee may have only one job role for 'job' role specs
    		if (IsJobRole) {
    			instance.JobRole = newRole;
    		}
    	}
    
    	public bool IsJobRole { get;set; }
    }
    
    public class EmployeeEx 
    {
    	public EmployeeRole JobRole { get;set;}
    }
    
    public class EmployeeRole {	}
