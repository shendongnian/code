    //create task service instance
    ITaskService taskService = new TaskSchedulerClass();
    taskService.Connect();
    ITaskDefinition taskDefinition = taskService.NewTask(0);
    taskDefinition.Settings.Enabled = true;
    taskDefinition.Settings.Compatibility = _TASK_COMPATIBILITY.TASK_COMPATIBILITY_V2_1;
    
    //create trigger for task creation.
    ITriggerCollection _iTriggerCollection = taskDefinition.Triggers;
    ITrigger _trigger = _iTriggerCollection.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
    _trigger.StartBoundary = DateTime.Now.AddSeconds(15).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
    _trigger.EndBoundary = DateTime.Now.AddMinutes(1).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
    _trigger.Enabled = true;
    
    ///get actions.
    IActionCollection actions = taskDefinition.Actions;
    _TASK_ACTION_TYPE actionType = _TASK_ACTION_TYPE.TASK_ACTION_EXEC;
    
    //create new action
    IAction action = actions.Create(actionType);
    IExecAction execAction = action as IExecAction;
    execAction.Path = @"C:\Windows\System32\notepad.exe";
    ITaskFolder rootFolder = taskService.GetFolder(@"\");
    
    //register task.
    rootFolder.RegisterTaskDefinition("test", taskDefinition, 6, null, null, _TASK_LOGON_TYPE.TASK_LOGON_NONE, null);
