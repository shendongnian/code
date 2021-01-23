        if (ticks.TypeOf == Period.Hour)
        {
            // fill a hashset with the range's unique hourly values 
            var rangehs = new HashSet<DateTime>();
            foreach (var r in range)
            {
                rangehs.Add(r.time.AddMinutes(-r.time.Minute));
            }
            // walk all the hours
            while (compareAt <= endAt)
            {
                // quickly check if it's a gap
                if (!rangehs.Contains(compareAt))
                    gaps.Add(new SomeValue() {     ...some dummy values..});
                compareAt = compareAt.AddTicks(ticks.Ticks);
            }
        }
