    public class MyViewModel : INotifyPropertyChanged
    {
        private string countText;
        public string CountText        
        {
            get { return this.countText; }
            set { this.countText = value; NotifyPropertyChanged("CountText"); }
        }
        .....snip.....
 
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(params string[] properties)
        {
            if (PropertyChanged != null)
            {
                foreach (string property in properties)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
    }
