    var employees = new List<Employee>
    { 
    	new Employee { Name="Dave", Age=25 },
    	new Employee { Name="John", Age=23 },
    	new Employee { Name="Michael", Age=30 },
    	new Employee { Name="Bobby", Age=30 }, 
    	new Employee { Name="Tom", Age=25 }, 
    	new Employee { Name="Jane", Age=21 }
    };
    
    var query = employees.GroupBy(employee => employee.Age, employee => employee.Name);
    
    foreach (IGrouping<int, string> employeeGroup in query)
    {
    	Console.WriteLine(employeeGroup.Key);
    	foreach (string name in employeeGroup)
    	{
    		Console.WriteLine($"=> {name}");
    	}
    }
