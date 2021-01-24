 c#
applicationDbContex.Students.IgnoreQueryFilters().Where(...)
     .Select(s => new {
         PersonalNumber = s.PersonalNumber,
         Milestones = s.Milestones 
     })
     .Include("Milestones.Type").ToArray();
and Include is useless when you use Select!
