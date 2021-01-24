    public class ReportServiceTests
    {
        private Tests tests = new Tests();
    	
    	[Fact]
    	public async Task CreateReport_WhenCalled_LogsTheCall()
    	{
    		tests.CreateReport_WhenCalled_LogsTheCall();
    	}
    
    	private class Tests : TestsFor<ReportService>
    	{
    		public async Task CreateReport_WhenCalled_LogsTheCall()
    		{
    			// Act
    			await Instance.CreateReport();
    
    			// Assert            
    			GetMockFor<ILogger>().Verify(logger => logger.Enter(Instance, nameof(Instance.CreateReport)), Times.Once());
    		}
    	}
    }
