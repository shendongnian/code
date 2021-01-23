    public class MyItemSource
    {
        private List<string> source = { ... };
    
        public MyItemSource()
        {
            this.ShowThisMany = 20;
        }
    
        public int ShowThisMany
        {
            get;
            set; // this should call\use the INotifyPropertyChanged interface
        }
    
        public IEnumerable<string> this[]
        {
            return this.source.Take(this.ShowThisMany);
        }
    }
    
    ...
    MyItemsSource myItemsSource = new MyItemsSource();
    ItemsControl.Source = myItemsSource;
    ...
    
    void OnShowMoreClicked(...)
    {
        myItemsSource.ShowThisMany = 50;
    }
