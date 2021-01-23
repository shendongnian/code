            // Round interval
            const int roundInterval = 15;
            var remainder = fromDate.TimeOfDay.Minutes % roundInterval;
            var curTime = remainder == 0 ? fromDate : fromDate.AddMinutes(roundInterval - remainder);
            curTime = curTime.AddSeconds(-curTime.TimeOfDay.Seconds);
            
            var delta = TimeSpan.FromMinutes(roundInterval);
            while (curTime < toDate)
            {
                while (curTime.DayOfWeek == DayOfWeek.Saturday || curTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    curTime = curTime.Date.AddDays(1);
                }
                if (curTime.TimeOfDay.Hours < 8)
                {
                    curTime = curTime.AddHours(8 - curTime.TimeOfDay.Hours);
                    curTime = curTime.AddMinutes(-curTime.TimeOfDay.Minutes);
                    continue;
                }
                if (curTime.TimeOfDay.Hours >= 17)
                {
                    curTime = curTime.AddHours(24 - curTime.TimeOfDay.Hours);
                    curTime = curTime.AddMinutes(-curTime.TimeOfDay.Minutes);
                    continue;
                }
                TSList.Add(new TimeSlot(curTime, true));
                curTime = curTime.Add(delta);
            }
        }
