    AutoMapper.Mapper.Initialize(m => m.AddProfile<YOUR AUTOMAPPER PROFILE>());
    AutoMapper.Mapper.AssertConfigurationIsValid();
    var options = new DbContextOptionsBuilder<TestContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    var context = new TestContext(options))
    context.Department.Add(new Department { DepartmentId = 2, DepartmentCode = "123", DepartmentName = "ABC" });
    context.SaveChanges();    
    var departmentRepository = new IRepository<Department>>(context);
    var departmentAppService = new DepartmentAppService(departmentRepository, AutoMapper.Mapper.Instance);
    var test = await departmentAppService.GetDepartmentById(5);
    Assert.Equal("123", test.DepartmentCode);
