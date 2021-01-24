    public List<DateTime> SelectedDates
    {
        get
        {
            if (ViewState["Dates"] != null)
                return (List<DateTime>)ViewState["Dates"];
            else
                return new List<DateTime>() { Calendar1.SelectedDate };
        }
        set
        {
            ViewState["Dates"] = value;
        }
    }
   
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        foreach (DateTime selectedDate in Calendar1.SelectedDates)
        {
            if (SelectedDates.Contains(selectedDate))
                SelectedDates.Remove(selectedDate);
            else
                SelectedDates.Add(selectedDate);
        }
        ViewState["Dates"] = SelectedDates;
        Session["SelectedDates"] = ViewState["Dates"];
    }
    protected void Calendar1_PreRender(object sender, EventArgs e)
    {
        Calendar1.SelectedDates.Clear();
        foreach (DateTime dt in SelectedDates)
            Calendar1.SelectedDates.Add(dt);
    }
