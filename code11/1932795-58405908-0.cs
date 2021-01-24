    var topMakes = Sitecore.Configuration.Settings
        .GetSetting("RACQ.JoinMembership.Top10CarMakes")
        .Split('|')
        .Select(topMake => topMake.ToLower());
    // Put any of the topMakes items at the beginning of listItems
    listItems = listItems
        .OrderByDescending(listItem => topMakes.Any(topMake => 
            topMake.Contains(listItem.Text.ToLower())))
        .ToList();
