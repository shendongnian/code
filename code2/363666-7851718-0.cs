    protected void Calendar1_Render(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsWeekend)
        {
            DropDownList d = new DropDownList();
            d.ID = "bah" + e.Day.Date.ToShortDateString();
            d.AutoPostBack = true;
            d.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
            d.Items.Add("A");
            d.Items.Add("B");
            d.Items.Add("C");
            e.Cell.Controls.Add(d);
        }
    }
