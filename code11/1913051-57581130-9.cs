    [TestClass]
    public class MyTestClass2 {
        [TestMethod]
        public void MyTestMethod() {
            //Arrange
            IEnumerable<Person> persons = new List<Person>() {
                new Person() { Name = "Nancy Davolio", DOB = DateTime.Parse("1948-12-08"), Email = "nancy.davolio@test.com" },
                new Person() { Name = "Andrew Fuller", DOB = DateTime.Parse("1952-02-19"), Email = "andrew.fuller@test.com" },
                new Person() { Name = "Janet Leverling", DOB = DateTime.Parse("1963-08-30"), Email = "janet.leverling@test.com" },
                new Person() { Name = "Margaret Peacock", DOB = DateTime.Parse("1937-09-19"), Email = "margaret.peacock@test.com" },
                new Person() { Name = "Steven Buchanan", DOB = DateTime.Parse("1955-03-04"), Email = "steven.buchanan@test.com" },
                new Person() { Name = "Michael Suyama", DOB = DateTime.Parse("1963-07-02"), Email = "michael.suyama@test.com" },
                new Person() { Name = "Robert King", DOB = DateTime.Parse("1960-05-29"), Email = "robert.king@test.com" },
                new Person() { Name = "Laura Callahan", DOB = DateTime.Parse("1958-01-09"), Email = "laura.callahan@test.com" },
                new Person() { Name = "Anne Dodsworth", DOB = DateTime.Parse("1966-01-27"), Email = "anne.dodsworth@test.com" }
            };
            var filter = new FilterModel {
                ColumnName = "Name",
                Term = "Nancy"
            };
            //Act
            var data = persons.FilterData(filter);
            //Assert
            data.Should().NotBeEmpty();
        }
    }
