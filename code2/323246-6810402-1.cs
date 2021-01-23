    public class CP : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public CP()
        {
            MovieList = new ObservableCollection<Movie>();
            MovieList.CollectionChanged += MovieListChanged;
        }
    
        public bool HasMovies
        {
            get { return MovieList != null && MovieList.Count > 0; }
        }
    
        public ObservableCollection<Movie> MovieList
        {
            get;
            private set;
        }
    
        private void MovieListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("HasMovies");
        }
    
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
