    [Fact]
    public async Task Get_DepartmentById_Are_Equal()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            // Arrange
            var departmentAppService = scope.ServiceProvider.GetServices<IDepartmentAppService>();
    
            // Act
            var departmentDto = await departmentAppService.GetDepartmentById(2);
    
            // Arrange
            Assert.Equal("123", departmentDto.DepartmentCode);
        }
    }
