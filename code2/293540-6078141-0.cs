    //-----------------------------------------------------------------------------
    // <copyright file="Program.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    namespace TaskSchedulerExample {
        using System;
        using TaskScheduler;
        class Program {
            static void Main(string[] args) {
                var scheduler = new TaskSchedulerClass();
                scheduler.Connect(null, null, null, null);
            
                ITaskDefinition task = scheduler.NewTask(0);
                task.RegistrationInfo.Author = "DCOM Productions";
                task.RegistrationInfo.Description = "Demo";
                ILogonTrigger trigger = (ILogonTrigger)task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_LOGON);
                trigger.Id = "Logon Demo";
                IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                action.Id = "Delete";
                action.Path = "c:\\delete.exe";          // Or similar path
                action.WorkingDirectory = "c:\\";        // Working path
                action.Arguments = "c:\\killme.txt";     // Path to your file
    
                ITaskFolder root = scheduler.GetFolder("\\");
                IRegisteredTask regTask = root.RegisterTaskDefinition("Demo", task, (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN, "");
            
                //Force run task
                //IRunningTask runTask = regTask.Run(null);
            }
        }
    }
