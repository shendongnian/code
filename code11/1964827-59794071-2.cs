    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool SetField<T>(ref T field, T value, [CallerMemberName] string memberName = "")
        {
            if (field != null)
            {
                if (field.Equals(value))
                    return false;
            }
            else if (value != null)
                return false;
            field = value;
            RaisePropertyChanged(memberName);
            return true;
        }
        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ApiViewModel : BaseViewModel
    {
        private bool _customerIsChecked;
        public bool CustomerIsChecked
        {
            get => _customerIsChecked;
            set => SetField(ref _customerIsChecked, value);
        }
    }
