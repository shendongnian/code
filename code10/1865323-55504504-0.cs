    public class EmployeeComparer : IEqualityComparer<Employee>
    {
    	public int GetHashCode(Employee co)
    	{
    		if (co == null)
    		{
    			return 0;
    		}
    		
    		return co.EmployeeNum.GetHashCode();
    	}
    
    	public bool Equals(Employee x1, Employee x2)
    	{
    		if (object.ReferenceEquals(x1, x2))
    		{
    			return true;
    		}
    
    		if (object.ReferenceEquals(x1, null) || object.ReferenceEquals(x2, null))
    		{
    			return false;
    		}
    
    		return x1.EmployeeNum == x2.EmployeeNum && x1.Sched == x2.Sched;
    	}
    }
