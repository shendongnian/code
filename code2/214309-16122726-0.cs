    public double DurationinMins(DateTime startDt, DateTime endDt)
        {
            var ts = endDt.Subtract(startDt);
            return ts.TotalMinutes;
        }
