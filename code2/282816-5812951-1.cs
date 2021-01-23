    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        for (int x = 0; x < ar.Count; x++)
        {
            //if the date is in the past, just mark it as booked.
            if (e.Day.Date < DateTime.Now)
            {
                e.Cell.BackColor = System.Drawing.Color.FromArgb(38, 127, 0);
                e.Cell.ForeColor = System.Drawing.Color.White;
            }
            
            if (e.Day.Date.ToShortDateString() == Convert.ToDateTime(((ListItem)ar[x]).Text).ToShortDateString())
            {
                switch (((ListItem)ar[x]).Value)
                { 
                    case "1":
                        e.Cell.BackColor = System.Drawing.Color.FromArgb(220,220,220);
                        break;
                    case "2":
                        e.Cell.BackColor = System.Drawing.Color.FromArgb(38,127,0);
                        e.Cell.ForeColor = System.Drawing.Color.White;
                        break;
                    case "3":
                        if (e.Day.IsWeekend)
                        {
                            e.Cell.BackColor = System.Drawing.Color.FromArgb(255,255,204);
                        }
                        else
                        {
                            e.Cell.BackColor = System.Drawing.Color.White;
                        }
                        break;
                    default:
                        e.Cell.BackColor = System.Drawing.Color.White;
                        break;
                }
            }
        }
    }
