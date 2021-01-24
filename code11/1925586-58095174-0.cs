    public abstract class StatisticsListItem
    {
        public DateTime Time { get; }
    }
    public class StatisticsListItem<T> : StatisticsListItem 
    { 
        public T Value { get; }
    }
