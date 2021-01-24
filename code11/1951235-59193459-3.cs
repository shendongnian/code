    // First query to get project
    var query1 =  from project in db.Project.Where(t => (t.Active || t.TempActive) && t.ProjectId == projectid)
                                join UP in db.User_X_Project on project.ProjectId equals UP.ProjectId
                                where (UP.UserId == userId && UP.Active)
                                orderby (project.Priority ?? int.MaxValue)
                                orderby (project.ProjectTitle)
                                .Select new { project = project }.ToList();
    // Second query to get projecttask from query1.project and execute store procedure
    var query2 = from projecttask in query1.project.ProjectTask.Where(t => t.Active && (
                                (includeArchived == true && t.TaskStatusId == (int?)TaskStatus.Archived) ||
                                (includeArchived == false && t.TaskStatusId != (int?)TaskStatus.Archived)) ||
                                 t.TaskStatusId != (int?)TaskStatus.Planned)
                                 join schedule in query1.project.ProjectTask.SelectMany(p => p.ProjectTaskSchedule) on projecttask.ProjectTaskId equals schedule.ProjectTaskId
                                 join daily in db.ProjectTaskSchedule.SelectMany(p => p.DailyStatus) on schedule.ProjectTaskScheduleId equals daily.ProjectTaskScheduleId
                                 where schedule.Active && daily.Active && projecttask.Active && schedule.ResourceId == userId && (
                                 (EntityFunctions.TruncateTime(daily.Date) >= EntityFunctions.TruncateTime(startDate.Date) &&
                                 EntityFunctions.TruncateTime(daily.Date) <= EntityFunctions.TruncateTime(endDate.Date))
                                 )
                                 orderby schedule.StartDate
                                 .Select new 
                                {                                 
                                    MajorMilestone = db.GetMajorMileStone(projecttask.ProjectTaskId).FirstOrDefault(),
                                }.ToList();
