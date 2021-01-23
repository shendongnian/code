    protected void RadCalendar1_DayRender1(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
    {
        if (e.Day.Date >= RadCalendar1.RangeMinDate.Date && e.Day.Date <= RadCalendar1.RangeMaxDate.Date)
        {
            e.Cell.Visible = true;
        }
        else
        {
            e.Cell.Visible = false;
        }
    }
