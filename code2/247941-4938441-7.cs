    public class TagCloudViewModel//:INotifyPropertyChanged
    {
        public ObservableCollection<AggregatedLabelModel> AggregatedLabels {get; set;}
        public CollectionView AggregatedLabelsView {get; set;} // <-This...
    
        public TagCloudViewModel()
        {
            var data = new DataAccess();
            AggregatedLabels = data.GetData();
    
            //...and this:
            AggregatedLabelsView  = (ListCollectionView)CollectionViewSource.GetDefaultView(AggregatedLabels);
            AggregatedLabelsView.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
    
        }
