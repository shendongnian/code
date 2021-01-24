    class Player : INotofyPropertyChanged
    {
        private int _life;
        public int Life
        {
            get { return _life; }
            set { _life = value; OnPropertyChanged("Life"); }
        }
        ....
    }
