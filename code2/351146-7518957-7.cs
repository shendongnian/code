    var people = from guy in guyArray 
                 group guy by guy.Name into g
                 select new { 
                     Name = g.Key,
                     Count = g.Count(),
                     HappyCount = g.Count(x => x.Mood == Mood.Happy),
                     SadCount = g.Count(x => x.Mood == Mood.Sad),
                     OkayCount = g.Count(x => x.Mood == Mood.Okay)
                 };
