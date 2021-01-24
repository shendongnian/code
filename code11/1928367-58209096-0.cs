        private static DateTime NextTime(DateTime value, TimeSpan interval)
        {
            var temp = value.Add(new TimeSpan(interval.Ticks / 2));
            var time = new TimeSpan((temp.TimeOfDay.Ticks / interval.Ticks) * interval.Ticks);
            if (time == new TimeSpan(0, 0, 0)) { time = new TimeSpan(24, 0,0); }
            var timeDiff = time - value.TimeOfDay;
            var finalDate = value.AddHours(timeDiff.Hours);
            finalDate = finalDate.AddMinutes(timeDiff.Minutes);
            finalDate = finalDate.AddSeconds(timeDiff.Seconds);
            return finalDate;
        }
