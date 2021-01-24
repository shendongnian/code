var s1 = new TestService();
if (!Environment.UserInteractive)
	ServiceBase.Run(new ServiceBase[] { s1 }); // when running as service
else
{
	s1.Start(args); // when running as console
	Console.ReadLine();
	s1.Stop();
}
this will start as windows service or console application. 
Put this code to the `Program.Main` method and run under debug.
PS there is [Topshelf library](http://topshelf-project.com) also that can deal this stuff for you (run application as service or console).
PPS seems that you will need to add `public void TestService.Start` method to make this `UserInteractive` approach works:
public class TestService : ServiceBase
{
  // existing code
  public void Start(string[] args)
  {
    OnStart(args);
  }
  public void Stop()
  {
    OnStop();
  }
}
