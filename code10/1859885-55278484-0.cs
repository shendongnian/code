    static void Main(string[] args)
    {
    	List<Employee> secondHighestSalaryPersons = Employee.GetAllEmployees()
    		 .GroupBy(x => x.Name)
    		 .Select(x =>
    		 {
    			 var group = x.ToList();
    
    			 if (group.Count > 1)
    				 return group.OrderByDescending(y => y.Salary).Skip(1).FirstOrDefault();
    			 else
    				 return group.FirstOrDefault();
    		 })
    		 .ToList();
    }
