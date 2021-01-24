    public class AcquiredDateGroup
    {
        public int ID { get; set; }
        public ObservableCollection<Feature> Features { get; set; }
    }
    public class Feature
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; } = false;
    }
