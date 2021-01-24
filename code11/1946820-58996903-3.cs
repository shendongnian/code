    [TestClass]
    public class MyTestClass1 {
        [TestMethod]
        public void MyTestMethod() {
            //Arrange
            int orderIds = 0;
            var faker = new Faker<User>()
               .StrictMode(false)
               .RuleFor(o => o.Id, f => ++orderIds)
               .RuleFor(o => o.UserName, f => f.Person.FullName) // This needs to be same as the next property
               .RuleFor(o => o.NormalizedUserName, f => f.Person.FullName.ToUpper()) // This should be same but uppercase
               .RuleFor(o => o.Email, f => $"{f.Person.FirstName}.{f.Person.LastName}@company.com");
            //Act
            var user = faker.Generate();
            //Assert
            user.UserName.ToUpper().Should().Be(user.NormalizedUserName);
        }
        public class User {
            public int Id { get; internal set; }
            public string UserName { get; internal set; }
            public string NormalizedUserName { get; internal set; }
            public string Email { get; internal set; }
        }
    }
