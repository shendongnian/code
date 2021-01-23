    void DoSomething(IPriorityProcess priorityProcess)
    {
        try
        {
            // stuff here
        }
        catch (Exception ex)
        {
            if (!priorityProcess.IsCompleted)
            {
                // wait here or whatever
            }
        }
    }
