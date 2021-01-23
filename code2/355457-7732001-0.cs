    public static void RestartServiceWithDependents(ServiceController service, TimeSpan timeout)
    {
        int tickCount1 = Environment.TickCount; // record when the task started
        // Get a list of all services that depend on this one (including nested
        //  dependencies)
        ServiceController[] dependentServices = service.DependentServices;
        // Restart the base service - will stop dependent services first
        RestartService(service, timeout);
        // Restore dependent services to their previous state - works because no
        //  Refresh() has taken place on this collection, so while the dependent
        //  services themselves may have been stopped in the meantime, their
        //  previous state is preserved in the collection.
        foreach (ServiceController dependentService in dependentServices)
        {
            // record when the previous task "ended"
            int tickCount2 = Environment.TickCount;
            // update remaining timeout
            timeout.Subtract(TimeSpan.FromMilliseconds(tickCount2 - tickCount1));
            // update task start time
            tickCount1 = tickCount2;
            switch (dependentService.Status)
            {
                case ServiceControllerStatus.Stopped:
                case ServiceControllerStatus.StopPending:
                    // This Stop/StopPending section isn't really necessary in this
                    //  case as it doesn't *do* anything, but it's included for
                    //  completeness & to make the code easier to understand...
                    break;
                case ServiceControllerStatus.Running:
                case ServiceControllerStatus.StartPending:
                    StartService(dependentService, timeout);
                    break;
                case ServiceControllerStatus.Paused:
                case ServiceControllerStatus.PausePending:
                    StartService(dependentService, timeout);
                    // I don't "wait" here for pause, but you can if you want to...
                    dependentService.Pause();
                    break;
            }
        }
    }
