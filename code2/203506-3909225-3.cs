    public class Data_DataViewModel : INotifyPropertyChanged
    {
        public int Value
        {
            get { return val; }
            set { val = value; } 
        }
        private int val;
        public Brush Color
        {
            get 
            {
                if (this.Value == pointer)
                {
                    return Brushes.Gray;
                }
                else
                {
                    return Brushes.Pink;
                }
            }
        }
        private int pointer;
        public void UpdateColor(int pointerValue)
        {
            this.pointer = pointerValue;
            OnPropertyChanged("Color");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
