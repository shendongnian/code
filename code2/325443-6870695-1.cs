    Dictionary<string, int> schedulesDateCount = new Dictionary<string, int>();
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        string date = Convert.ToDateTime(dt.Rows[i]["date"]).ToShortDateString();
        if(!schedulesDateCount.ContainsKey(date))
            schedulesDateCount[date] = 0;
        if(schedulesDateCount[date] < 3)
        {
            schedule[date] = (schedule[date] != null ? schedule[date].ToString() : "")    + Server.HtmlEncode(dt.Rows[i]["todo"].ToString()) + "<br />" + dt.Rows[i]["time"].ToString() + "<br />";
            schedulesDateCount[date] = schedulesDateCount[date] + 1;
        }
    }
    return schedule;
