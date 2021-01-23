    public string ModifyScheduledTaskSchedule(string TaskName, string Date, string Hour, string Minute)
            {
    
                string ReturnedTask = TaskName;
    
                
                    TaskScheduler.TaskScheduler ts = new TaskScheduler.TaskScheduler();
    
                    ts.Connect(PackagingServer, PkgServerUserName, "DOMAIN", PkgServerPassword);
    
                    IRegisteredTask task = ts.GetFolder("\\").GetTask(TaskName);
    
                    ITaskDefinition td = task.Definition;
    
                    td.Triggers[1].StartBoundary = Date + "T" + Hour + ":" + Minute + ":" + "00";
                   
                    ts.GetFolder("\\").RegisterTaskDefinition(TaskName, td, (int)_TASK_CREATION.TASK_UPDATE, "DOMAIN\\" + PkgServerUserName, PkgServerPassword, _TASK_LOGON_TYPE.TASK_LOGON_NONE, "");
    
               
                return ReturnedTask;
            }
