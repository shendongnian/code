            var range = new VisibleRange() { };
            var matched = userTrackingContext.EventLog.Where(a => a.MachineName.StartsWith(myMachine));
            if(matched != null)
            {
                range.start = matched.Min(a => a.EventDate);
                range.end = matched.Max(a => a.EventDate);
            }
