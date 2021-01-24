    // MVC Project
    var seasonLimits =
    	from s in context.Season
    		.Where(s => s.Locations.Project.Project_Group.Any(pg => pg.Project_Group_ID == Project_Group_ID))
    	group s by new
    	{
    		s.Year
    	} into grp
    	select new
    	{
    		grp.Key.Year,
    		Min_Start_Date = grp.Min(x => x.Start_Date),
    		Min_Start_Date_ID = grp.Min(x => x.Start_Date_ID),
    		Max_End_Date = grp.Max(x => x.End_Date),
    		Max_End_Date_ID = grp.Max(x => x.End_Date_ID)
    	};
    	
    var seasonHoursByYear =
        from d in context.AuxiliaryDateHours
        from sl in seasonLimits
        where d.Date_ID >= sl.Min_Start_Date_ID
            && d.Date_ID < sl.Max_End_Date_ID
        group d by new
        {
            d.Year
        } into grp4
        orderby grp4.Key.Year
        select new
        {
            Year = grp4.Key.Year,
            HoursInYear = grp4.Count()
        };
