    var query2 = db.tTask_User.Where(task => task.hasOwner == 0 || (task.Enabled && task.tTaskRecipientType.pk_taskrecipienttype == 5)); 
    
    var query = from items in query2                            
                select new MainGridDto()
                {
                     PK_Task = items.FK_Task,
                     TaskName = items.tTask.TaskName,
                     TaskRecipientType = items.tTaskRecipientType,
                     Owner = items.hasOwner == 0 ? "no owner" : items.tOfficeUser.Login,
                     TaskDescription = items.tTask.TaskDescription,
                     Enabled = items.tTask.Enabled,
                     tTaskTeam = items.tTask.tTaskTeam,
                     EmailBody = items.tTask.EmailBody,
                     EmailSubject = items.tTask.EmailSubject
                };
