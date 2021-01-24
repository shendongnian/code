    List<DataPoint> points = new List<DataPoint>();
    void setValues(char time, int rand)
    {
        Random rnd = new Random(rand);  // random data values
        points = new List<DataPoint>();
        DateTime dn = DateTime.Now;
        DateTime dw = new DateTime(dn.Year, dn.Month, dn.Day % 7 + 1); //my weeks start on monday
        DateTime dm = new DateTime(dn.Year, dn.Month, 1);
        DateTime dy = new DateTime(dn.Year, 1, 1);
        if (time == 'w') for (int i = 0; i < 7; i++)
                points.Add(new DataPoint(dw.AddDays(i).ToOADate(), rnd.Next(100) + 50));
        if (time == 'm') for (int i = 0; i < DateTime.DaysInMonth(dn.Year, dn.Month); i++)
                points.Add(new DataPoint(dm.AddDays(i).ToOADate(), rnd.Next(100) + 50));
        if (time == 'y') for (int i = 0; i < 12; i++)
                points.Add(new DataPoint(dy.AddMonths(i).ToOADate(), rnd.Next(100) + 50));
    }
