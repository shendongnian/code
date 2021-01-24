    public List<ActivityEditViewModal> GetAllActivites()
    {
        var staffRepo = new StaffRepositry(_db);
        List<ActivityHeader> activity = new List<ActivityHeader>();
        activity = _db.ActivityHeader.AsNoTracking()
           .Include(x => x.StaffMembers)
           .Include(x=>x.ActivityLines)
           .ToList();
 
        if (activity != null)
         {
             List<ActivityEditViewModal> activityDisplay = new 
               List<ActivityEditViewModal>();
               foreach (var x in activity)
               {
                  var customerDisplay = new ActivityEditViewModal()
                   {
                      ActivityHeaderId = x.ActivityHeaderId,
                      ActivityDate = x.ActivityDate,
                      Name = x.Name,
                      ActivityEndDate = x.ActivityEndDate,
                      Description = x.Description,
                      ActivityLines = x.ActivityLines
                  };
                      activityDisplay.Add(customerDisplay);
                 }
               return activityDisplay;          
    }
