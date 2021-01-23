	void Main()
	{
		List<Employee> AllEmployees = new List<Employee>();
		
		List<Cars> lcars1 = new List<Cars>();
		Cars car1 = new Cars();
		car1.CarType = Cars.CarTypes.Van;
		lcars1.Add(car1);lcars1.Add(car1);
		
		Cars car2 = new Cars();
		car2.CarType = Cars.CarTypes.SmallCar;
		lcars1.Add(car2);
		
		List<Cars> lcars2 = new List<Cars>();
		lcars2.Add(car1);lcars2.Add(car2);lcars2.Add(car2);
		
		AllEmployees.Add(new Employee(){ Name="emp1", Cars = lcars1});
		AllEmployees.Add(new Employee(){ Name="emp2", Cars = lcars2});
		AllEmployees.Add(new Employee(){ Name="emp3", Cars = lcars1 });
		AllEmployees.Add(new Employee(){ Name="emp4", Cars = lcars2});
		
		List<Employee> Temp = AllEmployees.Where(emps => emps.Cars.Any(cartype => cartype.CarType == Cars.CarTypes.Van)).ToList();
		
		List<Employee> EmployeesWithVans = (from item in Temp
				select new Employee{ 
											Name = item.Name, 
											Cars = (item.Cars.Where( car => car.CarType == Cars.CarTypes.Van)).ToList()
									}).ToList();
		
		EmployeesWithVans.Dump();
	}
