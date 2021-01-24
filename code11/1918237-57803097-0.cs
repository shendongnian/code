    var user = model.Username != null ? await UserManager.FindByNameAsync(model.Username) : null;
    
    var res = DB.UserWatchActivityLogs.Include(x => x.User).Include(x => x.Tutorial);
    // filter by Id if user is not null
    if (user != null)
    {
        res = res.Where(x => x.User_Id == user.Id);
    }
    
    // filter by tutorial name if it is not null
    if (!string.IsNullOrEmpty(model.TutorialName))
    {
        res = res.Where(x => x.Tutorial.Title.Contains(model.TutorialName);
    }
    
    // filter by date from (assuming model.DateTimeFrom is a string)
    if (DateTime.TryParse(model.DateTimeFrom, new CultureInfo("fa-IR"), DateTimeStyles.None, out dateFrom))
    {
        res = res.Where(x.DateTime >= dateFrom);
    }
    
    if (DateTime.TryParse(model.DateTimeTo, new CultureInfo("fa-IR"), DateTimeStyles.None, out dateTo))
    {
        res = res.Where(x.DateTime <= dateTo);
    }
    
    // materialise the results in a list, this is when the query is executed
    res = res.ToList();
