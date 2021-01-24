    the below should be able to translate to SQL correctly
    var qry = _(context.ControlActivities
        .Include(x => x.ControlActivityChangeLogs)
        .Include(x => x.Company)
        .Where(x => !x.IsDeleted 
                 && !x.IsArchived 
                 && x.ControlActivityChangeLogs.CurrentValue != null 
                 && x.ControlActivityChangeLogs.CurrentValue != ""
                 && x.ControlActivityChangeLogs.NewValue != null 
                 && x.ControlActivityChangeLogs.NewValue != ""
        ).AsQueryable();
