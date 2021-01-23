	List<Employee> Temp = AllEmployees.Where(emps => emps.Cars.Any(cartype => cartype.CarType == Cars.CarTypes.Van)).ToList();
	
	List<Employee> EmployeesWithVans = (from item in Temp
               select new Employee{ 
				                         Name = item.Name, 
										 Cars = (item.Cars.Where( car => car.CarType == Cars.CarTypes.Van)).ToList()
				                   }).ToList();
