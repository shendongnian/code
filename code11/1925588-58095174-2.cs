    public abstract class StatisticsListItem
    {
        public DateTime Time { get; protected set; }
    }
    public class StatisticsListItem<T> : StatisticsListItem 
    {
        public StatisticsListItem(DateTime time, T value)
        {
            Time = time;
            Value = value;
        }
 
        public T Value { get; }
    }
