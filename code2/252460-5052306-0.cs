    public class CurrentSelected:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
        
        private SolidColorBrush color;
        public SolidColorBrush Color
        {
            get { return color; }
            set { 
                if (this.color==value) return;
                this.color = value;
                Notify("Color");
            }
        }
        public CurrentSelected() { 
            this.color = new  SolidColorBrush(Colors.Orange);
        }
        
    }
