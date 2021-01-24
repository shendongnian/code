using System.Diagnostics;
Process yourProcess;
bool triggerRunning;
public void OnUpdate()
{
   bool triggerStillRunning = false;
   //list all processes
   var processes = Process.GetProcesses();
   foreach(var p in processes)
   {
      //if trigger process is running
      if (p.ProcessName == /*Photoshop*/)
      {
         //set variable indicating that it is still running
         triggerStillRunning = true;
         //if the process was not running last update
         if(!triggerRunning)
         {
            //start your application
            yourProcess = Process.Start(/*your app*/);
            //set variable indicating that the trigger is still running
            triggerRunning = true;
         }
      }
   }
   //check if the trigger was running last update but isnt running this update 
   if (!triggerStillRunning && triggerRunning)
   {
      //kill all instances of your application
      foreach (var process in Process.GetProcessesByName("whatever"))
      {
         process.Kill();
      }
   }
}
Please note that you still need to wrap this logic in a service. best look at the tutorial I linked you, the service will of cause have to be in a separate project and executable.
