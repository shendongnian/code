    List<Employee> employees = new List<Employee>()
                {
                    new Employee { Id = 1, UserName = "Anil" , Salary = 5000},
                    new Employee { Id = 2, UserName = "Sunil" , Salary = 6000},
                    new Employee { Id = 3, UserName = "Lokesh" , Salary = 5500},
                    new Employee { Id = 4, UserName = "Vinay" , Salary = 7000}
                };
    
    var emp = employees.OrderByDescending(x => x.Salary).Skip(1).FirstOrDefault();
