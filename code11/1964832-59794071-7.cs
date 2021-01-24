    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ApiViewModel : BaseViewModel
    {
        private bool _customerIsChecked;
        public bool CustomerIsChecked
        {
            get { return _customerIsChecked; }
            set
            {
                _customerIsChecked = value;
                RaisePropertyChanged(nameof(CustomerIsChecked));
            }
        }
    }
