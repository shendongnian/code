    public class AppViewModel : BaseBind
    {
        public AppViewModel()
        {
            ItemsList = new ObservableCollection<ItemsList >();
            ItemsList .CollectionChanged += (sender, e) =>
            {
                // Do something if the list changes (e.g. update another property in the viewmodel class)...
            };
        }
        public ObservableCollection<SampleObjectClass> ItemsList { get; set; }
    }
