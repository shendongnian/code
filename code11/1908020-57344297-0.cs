    public class DbFixture
    {
        public DbFixture()
        {
             var serviceCollection = new ServiceCollection();
             serviceCollection.AddDbContext<SharedServicesContext>(options => options.UseInMemoryDatabase(databaseName: "TestDatabase"));
             serviceCollection.AddTransient<IDepartmentRepository, DepartmentRepository>();
             serviceCollection.AddTransient<IDepartmentAppService, DepartmentAppService>();
    
             ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    
        public ServiceProvider ServiceProvider { get; private set; }
    }
    
    public class DepartmentAppServiceTest:IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvide;
    
        public DepartmentAppServiceTest(DbFixture fixture)
        {
            _serviceProvide = fixture.ServiceProvider;
        }
    
        [Fact]
        public async Task Get_DepartmentById_Are_Equal()
        {
            using(var scope = _serviceProvider.CreateScope())
            {   
                // Arrange
                var context = scope.ServiceProvider.GetServices<SharedServicesContext>();
                context.Department.Add(new Department { DepartmentId = 2, DepartmentCode = "123", DepartmentName = "ABC" });
                context.SaveChanges();
                var departmentAppService = scope.ServiceProvider.GetServices<IDepartmentAppService>();
    
                // Act
                var departmentDto = await departmentAppService.GetDepartmentById(2);
    
                // Arrange
                Assert.Equal("123", departmentDto.DepartmentCode);           
            }
        }
    }
