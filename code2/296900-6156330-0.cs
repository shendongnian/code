    public class HistoryItem
    {
        private IEnumerable<DateTime> _dateTimes;
        public TimeSpan? Average
        {
            get { 
                TimeSpan total = default(TimeSpan);
                DateTime? previous = null;
                int quotient = 0;
                foreach (var dateTime in _dateTimes.OrderBy(x => x))
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
