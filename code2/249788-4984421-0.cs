    var query = context.Classes
                  .Include("ClassComments")  // Only add this if you want eager loading of all realted comments
                  .OrderBy(c => c.Name)
                  .Skip(startRecord)
                  .Take(recordsToReturn)
                  .Select(c => new 
                     {
                       Class = c,
                       AttendeeCount = c.Attendees.Count(),
                       ClassCommentCount = c.ClassComments.Count() // Not needed because you are loading all Class comments so you can call Count on loaded collection
                     });
