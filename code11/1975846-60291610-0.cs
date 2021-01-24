    if (DateTime.UtcNow - d.LastUpdated <= TimeSpan.FromMinutes(30) && d.CountDiff > 1)
    {
        if (x == null)
        {
            DoAction();
            _DBcontext.TestEvents.Add(new TestEvents
            {
                AppGuid = (Guid)item.AppGuid,
                AppName = item.AppName,
                Timestamp = DateTime.UtcNow
            });
        }
        //This is useful if app have crashed or was not able to update in db, it will update the current timestamp. 
        else if (DateTime.UtcNow - x.Timestamp >= TimeSpan.FromMinutes(30))
        {
            x.Timestamp = DateTime.UtcNow;
        }
        else
        {
            //This will set the notification date in future 
            DateTime dbtimestamp = x.Timestamp;
            DateTime futureTime = dbtimestamp.AddMinutes(15);
    
            if (((DateTime.UtcNow - futureTime) - TimeSpan.FromSeconds(1)).Duration() < TimeSpan.FromSeconds(1.0))
            {
                DoAction();
                x.Timestamp = DateTime.UtcNow;
            }
        }
    }
