    [TestClass]
    public class PhoneNumberTests {
        [DataTestMethod]
        [DataRow("555-5555")]
        [DataRow("555-555-5555")]
        [DataRow("1-555-555-5555")]
        public void Should_Be_Valid(string number) {
            //Arrange
            var subject = new PhoneNumber(number);
            var context = new ValidationContext(subject, null, null);
            var results = new List<ValidationResult>();
            //Act
            var actual = Validator.TryValidateObject(subject, context, results, true);
            //Assert
            actual.Should().BeTrue();
            results.Should().BeEmpty();
        }
        [DataTestMethod]
        [DataRow("abcd")]
        [DataRow("5555a")]
        [DataRow("abc5555a")]
        public void Should_Not_Be_Valid(string number) {
            //Arrange
            var subject = new PhoneNumber(number);
            var context = new ValidationContext(subject, null, null);
            var results = new List<ValidationResult>();
            //Act
            var actual = Validator.TryValidateObject(subject, context, results, true);
            //Assert
            actual.Should().BeFalse();
            results.Should().NotBeEmpty();
        }
    }
    
