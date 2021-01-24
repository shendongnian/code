        var query = (from project in db.Project.Where(t => (t.Active || t.TempActive) && t.ProjectId == projectid)
                                    join UP in db.User_X_Project on project.ProjectId equals UP.ProjectId
                                    where (UP.UserId == userId && UP.Active)
                                    orderby (project.Priority ?? int.MaxValue)
                                    orderby (project.ProjectTitle)
                                    select new
                                    {
                                        Project = project,
        
                                        ProjectTask = from projecttask in project.ProjectTask.Where(t => t.Active && (
                                                                                                                        (includeArchived == true && t.TaskStatusId == (int?)TaskStatus.Archived) ||
                                                                                                                        (includeArchived == false && t.TaskStatusId != (int?)TaskStatus.Archived))
                                                      || t.TaskStatusId != (int?)TaskStatus.Planned)
                                                      join schedule in project.ProjectTask.SelectMany(p => p.ProjectTaskSchedule) on projecttask.ProjectTaskId equals schedule.ProjectTaskId
                                                      join daily in db.ProjectTaskSchedule.SelectMany(p => p.DailyStatus) on schedule.ProjectTaskScheduleId equals daily.ProjectTaskScheduleId
                                                      where schedule.Active && daily.Active && projecttask.Active && schedule.ResourceId == userId 
                                                      orderby schedule.StartDate
                                                      select new
                                                      {
        
                                                          ProjectTask = projecttask,                                                    
                                                          ProjectTaskSchedule = from projecttaskschedule in projecttask.ProjectTaskSchedule.Where(t => t.Active && t.ResourceId == userId)
                                                                                select new
                                                                                {
                                                                                    ProjectTaskSchedule = projecttaskschedule,
                                                                                    DailyStatus = projecttaskschedule.DailyStatus.Where(t => t.Active),
        
                                                                                },
                                                          CritiCality = from cr in db.CritiCality.Where(ts => ts.ProjectTaskId == projecttask.ProjectTaskId) select cr,
                    }
         }).AsEnumerable().select(row => new { // maybe you should call stored procedure here
             ts = row,
             MajorMilestone = db.GetMajorMileStone(projecttask.ProjectTaskId).FirstOrDefault()
    };
