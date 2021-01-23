    public class Utility : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isRed;
        public bool IsRed
        {
            get { return isRed; }
            set 
            { 
                isRed = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsRed"));
            }
        }
    }
