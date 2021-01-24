    [FunctionName("DemoScheduler")]
    public static async void Run([TimerTrigger("0 */5* * * *")]TimerInfo myTimer, TraceWriter log)
    {
    	new Runner().Run(myTimer, log);
     }
     
     public class Runner 
     {
     	public void Run(TimerInfo myTimer, ILogger log) 
    	{
    		// your code	
    	}	
     }
     
     [TestClass]
     public class RunnerTests
    {
    	[TestMethod]
    	public void Run_ShouldWorkCorrectly()
    	{
    		var timerInfo = new TimerInfo();
    		//Configure your timer here
    		
    		new Runner().Run(timerInfo, new StubLogger());
    		
    		//your test
    	}
    } 
