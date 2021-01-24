    the below should be able to translate to SQL correctly
    var qry = _context.ControlActivities
        .Include(x => x.ControlActivityChangeLogs)
        .Include(x => x.Company)
        .Where(x => 
            !x.IsDeleted && 
            !x.IsArchived && 
            (x.ControlActivityChangeLogs.CurrentValue != null 
        AND  x.ControlActivityChangeLogs.CurrentValue != "")  || 
            x.ControlActivityChangeLogs.NewValue != null 
        AND x.ControlActivityChangeLogs.NewValue != "")))
        .AsQueryable();
