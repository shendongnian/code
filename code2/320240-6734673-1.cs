    namespace XXXX.ViewModel
    {
    public class MainViewModel : ViewModelBase
    {
        private int _id;
        private string _total;
        private string _description;
        private ObservableCollection<Worker> _workers;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string Total
        {
            get { return _total; }
            set
            {
                if (value == _total) return;
                _total = value;
                RaisePropertyChanged("Total");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        public ObservableCollection<Worker> Workers
        {
            get { return _workers; }
            set
            {
                if (value == _workers) return;
                _workers = value;
                RaisePropertyChanged("Workers");
            }
        }
        //****************** You Logic *************************
        public MainViewModel()
        {
            Department department = new Department();
        }
        //****************** You Logic *************************
    }
    }
