    public class MainViewModel: INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        } 
    }
