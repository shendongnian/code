    var result = messages
        .GroupBy(m => m.GroupId)                                // Create Tuple ...
        .Select(g => (Group: g, GroupDate: g.Max(m => m.Date))) // ... with group and group date.
        .SelectMany(a =>              // Expand the group
            a.Group.Select(m =>       // Create new tuple with group date and model.
                (a.GroupDate,
                 Model: new MyViewModel() {
                     Id = m.Id,
                     Date = m.Date,
                     Text = m.Text,
                     GroupId = m.GroupId
                 })))
        .OrderByDescending(x => x.GroupDate)
        .ThenBy(x => x.Model.Date)
        .Select(x => x.Model);         // Extract the view model from the tuple.
