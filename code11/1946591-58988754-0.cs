    public class ItemTemplate :INotifyPropertyChanged
    {
        private bool _showProgress;
        public bool ShowProgress
        {
            get { return _showProgress; }
            set
            {
                _showProgress = value;
                RaisePropertyChanged("ShowProgress");
            }
        }
    
       public event PropertyChangedEventHandler PropertyChanged;
       protected void RaisePropertyChanged(string name)
         {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
         }
    }
