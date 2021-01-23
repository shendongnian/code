    MyEntities context = new MyEntities();
    
    var activities = (from act in context.Activities
                      where act.ActTwittered == false
                      select new { act.ActID, act.ActTitle, act.Category, act.ActDateTime, act.Location })
                     .ToArray();
    
    context.Dispose();
    //Do something with activities
