    public class DepartmentAppServiceTest : IClassFixture<CustomWebApplicationFactory<OriginalApplication.Startup>>
    {
        public CustomWebApplicationFactory<OriginalApplication.Startup> _factory;
        public DepartmentAppServiceTest(CustomWebApplicationFactory<OriginalApplication.Startup> factory)
        {
            _factory = factory;
            _factory.CreateClient();
        }
        [Fact]
        public async Task ValidateDepartmentAppService()
        {      
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                var departmentAppService = scope.ServiceProvider.GetRequiredService<IDepartmentAppService>();
                var dbtest = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                dbtest.Department.Add(new Department { DepartmentId = 2, DepartmentCode = "123", DepartmentName = "ABC" });
                dbtest.SaveChanges();
                var departmentDto = await departmentAppService .GetDepartmentById(2);
                Assert.Equal("123", departmentDto.DepartmentCode);
            }
        }
    }
