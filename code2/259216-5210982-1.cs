    //Set a time-out value.
    int timeOut = 5000;
    //Start the process.
    Process p = Process.Start(someProcess);
    //Wait for window to finish loading.
    p.WaitForInputIdle();
    //Wait for the process to exit or time out.
    p.WaitForExit(timeOut);
    //Check to see if the process is still running.
    if (p.HasExited == false)
    {
    	//Process is still running.
    	//Test to see if the process is hung up.
    	if (p.Responding)
        {
      	    //Process was responding; close the main window.
       	    p.CloseMainWindow();
        }
    	else
        {
            //Process was not responding; force the process to close.
            p.Kill();
        }
    }
    //continue
				
