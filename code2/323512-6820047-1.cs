        var result = dbContext.MasterPreAwards
            .Where(m => m.ID == masterPreAward.ID)
            .Select(m => new
            {
                ClientId = m.Cycle.Project.Program.ClientID,
                ApplicationId = m.MemberID,
                ProgramId = m.Cycle.Project.ProgramID,
                ProjectId = m.Cycle.ProjectID,
                EventTypeId = m.DataTrackings.Where(d => d.Finished
                    && x.EventTypeID==(int)FormEvents.Application)
                    .Select(d => d.EventTypeID).FirstOrDefault(),
                CycleId = m.CycleID,
                FormId = m.Cycle.CycleForms.Select(c => c.FormID).FirstOrDefault()
            })
            .Single();
        MasterPreAwardId = masterPreAward.ID;
        ClientId = result.ClientID;
        ApplicationId = result.MemberID;
        ProgramId = result.ProgramID;
        ProjectId = result.ProjectID;
        EventTypeId = result.EventTypeId;
        CycleId = result.CycleID;
        FormId = result.FormID;
