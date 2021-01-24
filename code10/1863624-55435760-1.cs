        public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double myWidth;
        public double MyWidth
        {
            get { return myWidth; }
            set 
            {
                if (value != this.myWidth)
                {
                    myWidth = value; 
                    NotifyPropertyChanged("MyWidth");
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            //set the width here in code behind
            this.MyWidth = 200;
        }
        protected virtual void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
