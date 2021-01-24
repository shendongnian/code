        [Fact]
        public void Sut_ReturnsEmployee_FromService()
        {
            var fixture = new Fixture();
            fixture.Customize<EmployeeModel>(e => e.With(x => x.Name, "Foo"));
            var expected = fixture.Create<EmployeeModel>();
            var foundEmployee = fixture.Create<EmployeeModel>();
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(f => f.GetEmployeeById(42)).Returns(foundEmployee);
            var sut = new EmployeeController(employeeServiceMock.Object);
            var actual = sut.GetEmployeeById(42);
            Assert.Equal(expected.Name, actual.Name);
        }
