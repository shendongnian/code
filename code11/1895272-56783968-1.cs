    public class Test : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _content;
        public int content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    if (value == 1)
                    {
                        foreGround = new SolidColorBrush(Colors.LightGreen);
                        backGround = new SolidColorBrush(Colors.DarkGreen);
                    }
                    else
                    {
                        foreGround = new SolidColorBrush(Colors.Gray);
                        backGround = new SolidColorBrush(Colors.LightGray);
                    }
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("content"));
                }
            }
        }
        private SolidColorBrush _backGround;
        public SolidColorBrush backGround
        {
            get { return _backGround; }
            set
            {
                if (_backGround != value)
                {
                    _backGround = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("backGround"));
                }
            }
        }
        private SolidColorBrush _foreGround;
        public SolidColorBrush foreGround
        {
            get { return _foreGround; }
            set
            {
                if (_foreGround != value)
                {
                    _foreGround = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("foreGround"));
                }
            }
        }
    }
