    public double MilliTimeStamp(DateTime TheDate)
            {
                DateTime d1 = new DateTime(1970, 1, 1);
                DateTime d2 = TheDate.ToUniversalTime();
                TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
    
                return ts.TotalMilliseconds;
            }
