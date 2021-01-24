    var vm = new DepartmentViewModel(); //<---- this is an example
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<DepartmentViewModel, Department>();
    });
    IMapper mapper = config.CreateMapper();
    //entity is a POCO Department Object. 
    var entity = mapper.Map<DepartmentViewModel, Department>(vm);
    //here you can pass the entity to EF for insert. 
    using (var ctx = new EmployeeContext())
    {
        ctx.Departments.Add(entity);
        ctx.SaveChanges();
    }
