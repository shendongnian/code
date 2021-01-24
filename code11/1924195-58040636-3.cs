    [TestClass]
    public class ExceptionHandlerFilterTests {
        [TestMethod]
        public void Should_Handle_Custom_Exception() {
            //Arrange
            var subject = new ExceptionHandlerFilter();
            var url = "http://example.com";
            var context = new ExceptionContext(Mock.Of<ActionContext>(), new List<IFilterMetadata>()) {
                Exception = new MovedPermanentlyException(url)
            };
            //Act
            subject.OnException(context);
            //Assert
            context.Result.Should()
                .NotBeNull()
                .And.BeOfType<RedirectResult>();
        }
    }
