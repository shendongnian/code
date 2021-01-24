public int ToWeekIndex(DateTime date)
{
   // Takes any date and maps it to a value that represents the week it resides in.
   Timespan ts = date - DateTime.MinValue // Monday, January 1, 0001;
   return ts.Days / 7; // Integer divide, drops the remainder.
}
public DateTime FromWeekIndex(int weekIndex)
{
   // Takes a week index and returns the Monday from it.
   Timespan ts = new Timespan(weekIndex * 7, 0, 0, 0); // Days, hours, minutes, seconds
   return DateTime.MinValue + ts;
}
Then to build out your weeks, you could do something to the effect of pseudocode:
all_weeks = []
for date in January 1, 2019 to December 31, 2019 step 7 days:
   week_index = ToWeekIndex(date)
   week_start = FromWeekIndex(week_index)
   week_end = week_start + 7 days - 1 second
   all_weeks += [week_start, week_end]
