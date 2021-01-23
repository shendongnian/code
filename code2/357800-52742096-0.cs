    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
            {
                if (e.Day.Date.DayOfWeek == DayOfWeek.Friday)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.BackColor = Color.AliceBlue;
                }
            }
