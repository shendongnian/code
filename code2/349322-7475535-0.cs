			var employees = new List<Employee>();
			employees.Add(new Employee{ID = 3, Name="Name1"});
			employees.Add(new Employee{ID = 1, Name="Name2"});
			employees.Add(new Employee{ID = 2, Name="Name3"});
			
			var orders = new long[]{2, 1, 3};
			
			var orderedEmployees = employees.OrderBy(e => Array.IndexOf(orders, e.ID));
			orderedEmployees.ToList().ForEach(e => Console.WriteLine(e.ID));
