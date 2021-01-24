    void setvalues(double total, DateTime date)
        {
            points = new List<DataPoint>();
            DateTime dn = DateTime.Now;
            DateTime dw = new DateTime(dn.Year, dn.Month, dn.Day % 7);            
            for (int i = 0; i < 7; i++)
            {
                if (Convert.ToInt32(date.DayOfWeek) == i )
                {
                    points.Add(new DataPoint(dw.AddDays(i).ToOADate(), total));
                    break;
                }
                else
                {
                    points.Add(new DataPoint(dw.AddDays(i).ToOADate(), 0));
                }
            }
        }
