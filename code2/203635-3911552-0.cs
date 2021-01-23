            var lines = new List<string>();
            var dict = lines.Select(l =>
            {
                var sp = l.Split('|');
                return new EventLogLine { EventName = sp[0], Message = sp[1], Date = DateTime.Parse(sp[2]) };
            })
            .GroupBy(e => e.EventName)
            .ToDictionary(grp => grp.Key, grp => grp.AsEnumerable());
