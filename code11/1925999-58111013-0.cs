    var overviewList = tmpList.GroupBy(x => x.ProjectID)
        .Select(x => new 
        {
            ProjectID = x.Key,
            ProjectTime = x.Sum(o => TimeSpan.Parse(o.ProjectTime).TotalMinutes)).ToString()
        });
