    public class ViewModel : AsyncBindableBase
    {
        public ObservableCollection<TData> Data
        {
            get { return Property.Get(GetDataAsync); }
        }
    
        private Task<ObservableCollection<TData>> GetDataAsync()
        {
            //Get the data asynchronously
        }
    }
