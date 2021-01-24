    public class AcquiredDateGroup
    {
        public int ID { get; set; }
        public ObservableCollection<Feature> Features { get; set; }
        public List<Feature> FeaturesIsChecked
        {
            get
            {
                return Features.Where(x => x.IsSelected == true).ToList();
            }
        }
    }
