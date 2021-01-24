    for (int i = 12; i >= 1; i--)
    {
        DateTime date = DateTime.Now.AddYears(-1).AddMonths(i);
        ListItem li = new ListItem(date.ToString("Y"), date.ToString("yyyy-MM-01"));
        ddlMonth.Items.Add(li);
    }
