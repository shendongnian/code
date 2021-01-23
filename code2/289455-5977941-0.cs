    private void MyPingThread(object state)
    {
        ThreadExitState lstate = state as ThreadExitState;
        EventWaitHandle handle = new EventWaitHandle(false, EventResetMode.ManualReset);
        while (true)
        {
            if (lstate != null)
            {
               if (!lstate.Active)
                   return;
            }
            handle.WaitOne(1000 * 60 * 60 * 4); // Run the task each 4 hours
            //Do your work here
        }
    }
