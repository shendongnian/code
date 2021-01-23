    // counts range overlaps
    int counter = 0;
    // saves previous date to calculate midrange date
    DateTime left = DateTime.Now;
    // get mid range dates
    IList<DateTime> dates = this.DateRanges
        // select range starts and ends
        .SelectMany(r => new[] {
            new {
                Date = r.From,
                Counter = 1
            },
            new {
                Date = r.To,
                Counter = -1
            }
        })
        // order dates because they come out mixed
        .OrderBy(o => o.Date)
        
        // convert dates to ranges and when non-empty return mid date
        .Select(o => {
            // calculate middle date if range isn't empty and longer than 0
            DateTime? result = null;
            if ((counter != 0) && (left != o.Date))
            {
                result = o.Date.AddTicks(new DateTime((o.Date.Ticks - left.Ticks) / 2).Ticks);
            }
            // prepare for next date range
            left = o.Date;
            counter += o.Counter;
            // return middle date when applicable
            return result;
        })
        
        // exclude empty and zero width ranges
        .Where(d => d.HasValue)
        
        // collect non nullable dates
        .Select(d => d.Value)
        .ToList();
