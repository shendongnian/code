        TaskScheduler.TaskScheduler scheduler = new TaskScheduler.TaskScheduler();
        scheduler.Connect(null, null, null, null); //run as current user.
        ITaskDefinition taskDef = scheduler.NewTask(0);
        taskDef.RegistrationInfo.Author = "Me me me";
        taskDef.RegistrationInfo.Description = "My description";
        taskDef.Settings.ExecutionTimeLimit = "PT10M"; // 10 minutes
        taskDef.Settings.DisallowStartIfOnBatteries = false;
        taskDef.Settings.StopIfGoingOnBatteries = false;
        taskDef.Settings.WakeToRun = true;
        ITimeTrigger trigger = (ITimeTrigger)taskDef.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
        DateTime nextRun = DateTime.Now.AddMinutes(1); // one minute from now
        trigger.StartBoundary = nextRun.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
        IExecAction action = (IExecAction)taskDef.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
        action.Id = "exe name";
        action.Path = "path to exe";
        action.WorkingDirectory = "working dir";
        action.Arguments = "app arguments";  /// <-- here you put your arguments..
        ITaskFolder root = scheduler.GetFolder("\\");
        IRegisteredTask regTask = root.RegisterTaskDefinition(
            "My task name",
            taskDef,
            (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE,
            null, // user
            null, // password
            _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN, //User must already be logged on. The task will be run only in an existing interactive session.
            "" //SDDL
            );
