    //...
    services.AddSingleton<IEmployee, Employee>((ctx) => {
        EmployeeRepo employeeRepo = new EmployeeRepo(new DBContext(optionsBuilder.Options));
        IMemoryCache memoryCache = ctx.GetService<IMemoryCache>();
        IPerson person = ctx.GetService<IPerson>(); //<-- gets the registered singleton
        return new Employee(employeeRepo, memoryCache, person);
    });
    //...
