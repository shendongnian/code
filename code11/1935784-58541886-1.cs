    public class ViewModel : INotifyPropertyChanged {
        private ObservableCollection<HeaderViewModel> headers { get; set; }
        public ObservableCollection<HeaderViewModel> Headers {
            get => headers;
            set {
                headers = value;
                OnPropertyChanged();
            }
        }
    
        //constructor
        public ViewModel() {
            List<Header> queriedHeaders = new List<Header>();
            
            //please fetch data inside your viewmodel btw, currently you do it inside the view.
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Header>();
                queriedHeaders = conn.Query<Header>("select * from Header").ToList();
            }
    
            List<HeaderViewModel> _headers = new List<HeaderViewModel>();
            foreach(Header h in queriedHeaders) {
                var hvm = new HeaderViewModel(h);
                _headers.Add(hvm);
            }
    
            this.Headers = new ObservableCollection<HeaderViewModel>(_headers);
        }
    }
