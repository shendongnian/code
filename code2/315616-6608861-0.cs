    public class AggregateCount
    {
        public string Name { get; private set; }
        public int Count { get; private set; }
        public AggregateCount(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }
    }
    var aggregateCounts = objects.GroupBy(o => o.category).Select(g => new AggregateCount(g.Key, g.Count()));
    ObservableCollection<AggregateCount> categoryCounts = new ObservableCollection<AggregateCount>(aggregateCounts); 
