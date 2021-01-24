    var query1 = from items in db.tTasks
                 where items.hasOwner == 0
                 select new MainGridDto() {
                     PK_Task = items.PK_Task,
                     TaskName = items.TaskName,
                     TaskRecipientType = null,
                     Owner = "no owner",
                     TaskDescription = items.TaskDescription,
                     Enabled = items.Enabled,
                     tTaskTeam = items.tTaskTeam,
                     EmailBody = items.EmailBody,
                     EmailSubject = items.EmailSubject
                 };
    var query2 = from items in db.tTask_User
                 where items.tTaskRecipientType.pk_taskrecipienttype == 5 && items.tTask.Enabled
                 select new MainGridDto() {
                     PK_Task = items.FK_Task,
                     TaskName = items.tTask.TaskName,
                     TaskRecipientType = items.tTaskRecipientType,
                     Owner = items.tOfficeUser.Login,
                     TaskDescription = items.tTask.TaskDescription,
                     Enabled = items.tTask.Enabled,
                     tTaskTeam = items.tTask.tTaskTeam,
                     EmailBody = items.tTask.EmailBody,
                     EmailSubject = items.tTask.EmailSubject
                 };
