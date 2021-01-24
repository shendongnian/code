    public class ViewModel : INotifyPropertyChanged {
        [...]
        private ObservableCollection headerDetailsList { get; set; }
        public ObservableCollection<HeaderDetails> HeaderDetailList {
            get => headerDetailsList;
            set {
                headerDetailsList = value;
                OnPropertyChanged();
            }
        }
        [...]
    
        public ViewModel() {
            [...]
            var _headerDetailList = new List<HeaderDetails>();
            var headerIds = QueryAllHeaderIds() //Should return a list of all header Ids in your SQLite header table.
    
            foreach(var headerId in headerIds) {
                 _headerDetailsList.Add(new HeaderDetails(headerId));
            }
    
            HeaderDetailList = new ObservableCollection(_headerDetailList);
        }
    }
