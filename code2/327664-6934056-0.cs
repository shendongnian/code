    Data.Shift s = new Data.Shift();
    context.Shifts.AddObject(s);  // Add a new shift
    foreach (var t in shift.Tags) 
    {  //shift object is a cached object
         Data.Tag dt = new Data.Tag
         {
             TagID = t.TagID,
             Name = t.Name,
             OrgID = t.OrgID,
         };
         context.Tags.Attach(Tag); // Attach an existing tag
         s.Tags.Add(dt);
     }
     context.SaveChanges();
