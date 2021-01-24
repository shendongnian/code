    var results = alertlist.OrderBy(a => a.SenderName)
                           .ThenBy(a => a.EventName)
                           .GroupBy(a => a.SenderName)
                           .Select(x => new
                               {
                                  x.Key,
                                  count = x.Count(),
                                  EventNames = x.GroupBy(y => y.EventName)
                               });
