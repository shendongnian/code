    public class StatisticsList
    {
        public List<StatisticsListItem> Values { get; set; } = new List<StatisticsListItem>();
        public void TryAdd<T>(DateTime dateTime, T value)
        {
            // Adding an item of generic type to non-generic list:
            Values.Add(new StatisticsListItem<T>(dateTime, value));
        }
        public IEnumerable<StatisticsListItem<T>> TryGetFrom<T>(DateTime dateTime) 
        {  
            // Dynamically filtering only items of specific generic type
            return Values
                .OfType<StatisticsListItem<T>>() // computationally ineffective, subject to improvement ;)
                .Where(t => t.Time >= dateTime); // same, just an example
        }
    }
