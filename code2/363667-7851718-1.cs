     protected void Calendar1_Render(object sender, DayRenderEventArgs e)
            {
                if (e.Day.IsWeekend)
                {
                    DropDownList d = new DropDownList();
                    d.ID = "bah" + e.Day.Date.ToShortDateString();
                    d.Items.Add("A");
                    d.Items.Add("B");
                    d.Items.Add("C");
                    d.Attributes.Add("onchange", "__doPostBack();");
                    e.Cell.Controls.Add(d);
                }
            }
