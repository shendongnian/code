    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (todo.FindRows(e.Day.Date).Length > 0)
            e.Cell.BackColor = System.Drawing.Color.Aqua;
        if (e.Day.Date.Day == 18)
            e.Cell.Controls.Add(new LiteralControl("<br />Test to show on the calendar."));
    }
