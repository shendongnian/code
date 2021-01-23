    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public Window1()
        {
            InitializeComponent();
        }
        public bool HideRightColumn
        {
            get
            {
                return this.Width < 200;
            }
        }
        private void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("HideRightColumn"));
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
