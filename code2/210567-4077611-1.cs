    void Main()
    {
    	var lst = new [] {
    		new Extensions.Employee{ EmployeeId = 1, Name = "A", ManagerId = null }, 
    		new Extensions.Employee{ EmployeeId = 2, Name = "B", ManagerId = null }, 
    		new Extensions.Employee{ EmployeeId = 3, Name = "C", ManagerId = 1 }, 
    		new Extensions.Employee{ EmployeeId = 4, Name = "D", ManagerId = 3 }, 
    		new Extensions.Employee{ EmployeeId = 5, Name = "E", ManagerId = 2 }
    	};
    	
    	lst.GetTreeForEmployeeNumber(4).Dump();
    }
    
    public static class Extensions {
    
    	public class Employee {
    		public int EmployeeId { get; set; }
    		public string Name { get; set; }
    		public int? ManagerId { get; set; }
    	}
    	
    	public static IEnumerable<Employee> GetTreeForEmployeeNumber(this IEnumerable<Employee> source, int startingId) {
    		var result = source.Where(x => x.EmployeeId == startingId).FirstOrDefault();
    		if (result != null) {
    			var resultAsE = new [] { result };
    			if (!result.ManagerId.HasValue)
    				return resultAsE;
    			return resultAsE.Union(source.Except(resultAsE).GetTreeForEmployeeNumber(result.ManagerId.Value));
    		}
    		return new Employee [] { };
    	}
    }
