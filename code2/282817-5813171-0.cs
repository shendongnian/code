       protected void MyDayRenderer(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsToday)
            {
                e.Cell.BackColor = System.Drawing.Color.Aqua;
            }
            if (e.Day.Date == new DateTime(2011,5,1))
            {
                e.Cell.BackColor = System.Drawing.Color.Beige;
            }
        }
        
