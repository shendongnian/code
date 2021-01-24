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
               .RuleFor(o => o.NormalizedUserName, f => f.Person.FullName.ToUpper()); // This should be same but uppercase
            //Act
            var users = faker.Generate(3);
            //Assert
            users[0].UserName.ToUpper().Should().Be(users[0].NormalizedUserName);
        }
        public class User {
            public int Id { get; internal set; }
            public string UserName { get; internal set; }
            public string NormalizedUserName { get; internal set; }
        }
    }
