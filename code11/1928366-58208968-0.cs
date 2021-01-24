 private static DateTime NextTime(DateTime value, TimeSpan interval)
 {
     var temp = value.Add(new TimeSpan(interval.Ticks / 2));
     var time = new TimeSpan((temp.TimeOfDay.Ticks / interval.Ticks) * interval.Ticks);
     return temp.Date.Add(time);
 }
The reason for this is because you're adding your interval to the value. If it rolls over a midnight/end of day your `value.Date` will return the wrong day. Since you store `temp`, you can return `temp.Date.Add(time)`
