    if (date.Date == DateTime.Today) {
        result = "today, " + date.ToString("t");
    } else if (date.Date.Day == DateTime.Today.AddDays(-1).Day) {
        result = "yesterday, " + date.ToString("t");
    } else {
        result = (new TimeSpan(DateTime.Now.Ticks).Days - new TimeSpan(date.Ticks).Days) + " days ago";
    }
