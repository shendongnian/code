    var manager = new ActivityManager(mySiteContext);
    
    if (myDate <= manager.MinEventTime)
    {
      myEvents = manager.GetActivitiesForMe(manager.MinEventTime);
    }
    else
    {
      myEvents = manager.GetActivitiesForMe(myDate, this.MaxItemsToDisplay); 
    }
