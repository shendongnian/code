    public string getFormattedTimeFromMilliSecond(double milliSecond)
        {
     
            TimeSpan t = TimeSpan.FromMilliseconds(milliSecond);
     
            string formatedTime = string.Format("{0:D2}H:{1:D2}M:{2:D2}S",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds);
     
            return formatedTime;
    }
