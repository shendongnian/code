    public class Argomenti : INotifyPropertyChanged
      {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Capitolo
        {
            get;
            set;
        }
        public string Descrizione
        {
            get;
            set;
        }
    
        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
                }
            }
        }
        
        public void SetColors(bool isSelected)
        {
            if (isSelected)
            {
                BackgroundColor = Color.FromRgb(0.20, 0.20, 1.0);
            }
            else
            {
                BackgroundColor = Color.FromRgb(0.95, 0.95, 0.95);
            }
        }
    }
