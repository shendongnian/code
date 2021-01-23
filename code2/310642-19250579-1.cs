    private void CloseMainApp() 
    {
       Process[] processes = Process.GetProcessesByName("MyProcessName");
       Process myprocess= null;
       if (processes.Length > 0)
       {
          myprocess = processes[0];
          string evtName = "MyExitRequest" + myprocess.Id; // the same event name
          EventWaitHandle evt = new EventWaitHandle(false, EventResetMode.ManualReset, evtName);
          evt.Set(); // triggers the event at the main app
          if (!myprocess.WaitForExit(10000)) // waits until the process ends gracefuly
          {
             // if don't...
             myprocess.Kill();
          }
       }
    }
