		[TestFixture]
        public class TestClassProttected
        {
            [Test]
            public void all_bad_words_should_be_scrubbed()
            {
                //Arrange
                var mockCustomerNameFormatter = new Mock<ClassProtected>();
                mockCustomerNameFormatter.Protected()
                    .Setup<string>("ProtectedFunction", ItExpr.IsAny<string>())
                    .Returns("here can be any value")
                    .Verifiable(); // you should call this function in any case. Without calling next Verify will not give you any benefit at all
                //Act
                mockCustomerNameFormatter.Object.From(new Customer());
                //Assert
                mockCustomerNameFormatter.Verify();
            }
        }
