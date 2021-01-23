    List<Employee> Employees = GetAllEmployees();
    
    foreach(Employee oEmployee in Employees.ApplyDynamicSort(eEmployeeSort))
    {
    	//do stuff
    }
    
    public static IOrderedEnumerable<Employee> ApplyDynamicSort(this List<Employee> lEmployees, Enums.EmployeeSort eEmployeeSort)
    {
    	switch (eEmployeeSort)
    	{
    		case Enums.EmployeeSort.Name_ASC:
    			return lEmployees.OrderBy(x => x.Name);
    		case Enums.EmployeeSort.Name_DESC:
    			return lEmployees.OrderByDescending(x => x.Name);
    		case Enums.EmployeeSort.Department_ASC_Salary_DESC:
    			return lEmployees.OrderBy(x => x.Department).ThenByDescending(y => y.Salary);
    		default:
    			return lEmployees.OrderBy(x => x.Name);
    	}
    }
