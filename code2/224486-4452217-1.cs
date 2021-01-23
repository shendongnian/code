    public partial class Test
    {
        public int AB
        {
            get { return A * B; }
        }
        public partial void OnAChanged()
        {
            OnPropertyChanged("AB");
        }
        public partial void OnBChanged()
        {
            OnPropertyChanged("AB");
        }
    }
