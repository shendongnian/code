    namespace XXXX.ViewModel
    {
        public class MainViewModel : ViewModelBase
        {
            private int _id;
            private string _total;
    
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
        }
    }
