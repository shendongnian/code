    Data.Shift s = new Data.Shift();
    foreach (var t in shift.Tags) 
    {  //shift object is a cached object
         Data.Tag dt = new Data.Tag
         {
             TagID = t.TagID,
             Name = t.Name,
             OrgID = t.OrgID,
         };
         s.Tags.Add(dt);
     }
     context.Shifts.AddObject(s);
     // Now shift and all tags are added
     // Change the state of each tag to unchanged
     foreach (var tag in s.Tags)
     {
         context.ObjectStateManager.ChangeEntityState(tag, EntityState.Unchanged);
     }
     context.SaveChanges();
