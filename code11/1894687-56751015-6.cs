    public class MvItems : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void  RaisePropertyChanged(
                [System.Runtime.CompilerServices.CallerMemberName]
                string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string mvName;
        public string MvName
        {
            get => return mvName; 
            set
            {
                mvName = value;
                RaisePropertyChanged();
            }
        }
        private bool isChecked;
        public Bool IsChecked
        {
            get => return isChecked; 
            set
            {
                isChecked = value;
                RaisePropertyChanged();
            }
        }
    }
