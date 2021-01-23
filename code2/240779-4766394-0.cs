    DateTime today = DateTime.Now;
    var events = context.Events
                    .OrderBy(e => Math.Abs((today.Date - e.DueDate).Days))
                    .Take(5)
                    .ToList();
