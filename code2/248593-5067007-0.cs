    [TestFixture]
    public class ReportSaga_HandleRequestReportMessageTests
    {
    	[TestFixtureSetUp]
    	public void SetUp()
    	{
    		var assemblies = new[]
    					 {
    						 typeof (ReportSaga).Assembly,
    						 typeof (RequestReportMessage).Assembly,
    						 typeof (PollingReportStatusMessage).Assembly,
    						 Assembly.Load("NServiceBus"),
    						 Assembly.Load("NServiceBus.Core")
    					 };
    
    		Test.Initialize(assemblies);
    	}
    
    	[Test]
    	public void HandleRequestReportMessageTests()
    	{
    	
    		var message = new RequestReportMessage { Id = 1234, ReportDate = DateTime.Now };
    		
    		Test.Saga<ReportSaga>()
    			.ExpectPublish<PublishMessage>(e => e.SomePropertyOfPublishMethod == "value")
    			.When(x => x.Handle(message));
    
    	}
    }
