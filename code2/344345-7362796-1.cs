    foreach (var v in t)
    {
        TableClassName tgData = new TableClassName();
        tgData.PK = v.PK;
        tgData.Date = v.Date;
        tgData.Counted= v.Counted;
        tgData.Time = v.Time;
        tgData.MaxHR = v.MaxHR;
        tgData.PeakCal = v.PeakCal;
        tgData.PowerIndex = v.PowerIndex;
        tgData.Target = v.Target;
        tgData.RepTotal = v.RepTotal;
        tgData.Lifted = v.Lifted;
        tgData.UserID = v.UserID;
        tgdd.Add(tgData);
    }
