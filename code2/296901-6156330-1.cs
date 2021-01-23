    public class HistoryItem
    {
        private IEnumerable<DateTime> _dateTimes;
        public TimeSpan? Average
        {
            get { 
                TimeSpan total = default(TimeSpan);
                DateTime? previous = null;
                int quotient = 0;
                var sortedDates = _dateTimes.OrderBy(x => x);
                foreach (var dateTime in sortedDates)
                {
                    if (previous != null)
                    {
                        total += dateTime - previous.Value;
                    }
                    ++quotient;
                    previous = dateTime;
                }
                return quotient > 0 ? (TimeSpan.FromMilliseconds(total.TotalMilliseconds/quotient)) as TimeSpan? : null;
            }
        }
    }
