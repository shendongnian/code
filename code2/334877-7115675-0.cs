    public class TimestampedItem<T> : IComparable<TimestampedItem<T>>
    {
        public DateTime TimeStamp { get; set; }
        public T Data { get; set; }
        public int CompareTo(TimestampedItem<T> other)
        {
            return TimeStamp.CompareTo(other.TimeStamp);
        }
    }
    public void ReadFirstFromEachQueue<T>(IEnumerable<Queue<TimestampedItem<T>>> queues)
    {
        while (true)
        {
            var firstItems = new List<TimestampedItem<T>>(queues.Select(q => { lock (q) { return q.Peek(); } }));
                ProcessItem(firstItems.OrderBy(tsi => tsi.TimeStamp).First());
            }
        }
    }
