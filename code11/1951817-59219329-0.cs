CSharp
var actionContext = new ActionContext()
{
  HttpContext = new DefaultHttpContext(),
  RouteData = new RouteData(),
  ActionDescriptor = new ActionDescriptor()
};
After you are able to instantiate the `ActionContext` you can instantiate the ExceptionContext. Here we are also mocking the exception that is being used to build the `ExceptionContext`. This is the most important step as this is the value which changes the behavior we are testing.
CSharp
// The stacktrace message and source member variables are virtual and so we can stub them here.
var mockException = new Mock<Exception>();
mockException.Setup(e => e.StackTrace)
  .Returns("Test stacktrace");
mockException.Setup(e => e.Message)
  .Returns("Test message");
mockException.Setup(e => e.Source)
  .Returns("Test source");
var exceptionContext = new ExceptionContext(actionContext, new List<FilterMetadata>())
{
  Exception = mockException.Object
};
Doing it this way allows you to adequately test the behavior of an exception filter when given different exception types. 
Full code:
CSharp
[Fact]
public void TestExceptionFilter()
{
  var actionContext = new ActionContext()
  {
    HttpContext = new DefaultHttpContext(),
    RouteData = new RouteData(),
    ActionDescriptor = new ActionDescriptor()
  };
  // The stacktrace message and source member variables are virtual and so we can stub them here.
  var mockException = new Mock<Exception>();
  mockException.Setup(e => e.StackTrace)
    .Returns("Test stacktrace");
  mockException.Setup(e => e.Message)
    .Returns("Test message");
  mockException.Setup(e => e.Source)
    .Returns("Test source");
  // the List<FilterMetadata> here doesn't have much relevance in the test but is required 
  // for instantiation. So we instantiate a new instance of it with no members to ensure
  // it does not effect the test.
  var exceptionContext = new ExceptionContext(actionContext, new List<FilterMetadata>())
  {
    Exception = mockException.Object
  };
  var filter = new CustomExceptionFilter();
  filter.OnException(exceptionContext);
  // Assumption here that your exception filter modifies status codes.
  // Just used as an example of how you can assert in this test.
  context.HttpContext.Response.StatusCode.Should().Be(500, 
    "Because the response code should match the exception thrown.");
}
