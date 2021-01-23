    public class Tile : INotifyPropertyChanged
    {
        private string character;
        public string Charater
        {
            get
            {
                return character;
            }
            set
            {
                if(character != value)
                {
                    character = value;
                    OnPropertyChanged("Character");
                }
            }
        }
        private int x; // repeat for y and Y
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if(x != value)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var p = PropertyChanged;
            if(p != null)
            {
                p(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
