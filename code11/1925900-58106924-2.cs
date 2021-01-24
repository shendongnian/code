C#
using Timer = System.Timers.Timer;
public void Start()
{
    try
    {
        _timer = new Timer(Configuration.Configuration.MainLoopIntervalMs) {AutoReset = false};
        _timer.Elapsed += Test;
        _timer.Start();
    }
    catch (Exception e)
    {
        _logger.Error(e, "Exception ");
    }   
}
private void Test(object sender, ElapsedEventArgs eventArgs)
{
   // No code outside try-catch
   try
   {
       _logger.Debug("Test - Start");
       // Do all your work
       Console.WriteLine("Im doing here some more stuff");
   }
   catch(Exception e)
   {
       _logger.Error(e, "Some usefull description")
   }
   finally
   {
       _timer.Start();
       _logger.Debug("_timer restarted"); 
   }
}
