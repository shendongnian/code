    var today=items.Where(l=>l.StartDate>DateTime.Now.Subtract(TimeSpan.FromDays(1)));
    var lastweek=items.Where(l=>l.StartDate>DateTime.Now.Subtract(TimeSpan.FromDays(7)));
    var lastyear=items.Where(l=>l.StartDate>DateTime.Now.Subtract(TimeSpan.FromDays(365)));
	
    var result = today.Select(d => new { Group="Last Day",item=d})
                      .Union(lastweek.Select(w => new {Group="Last Week",item=w}))
                      .Union(lastyear.Select(y => new {Group="Last Year",item=y}))
                      .GroupBy (l => l.Group,l=>l.item);
