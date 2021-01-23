    namespace TestBinding
    {
        public partial class Window1 : Window, INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(String _Prop)
            {
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(_Prop));
                }
            }
            #endregion
    
            bool property = true;
    
            public Window1()
            {
                InitializeComponent();
                this.DataContext = this;
            }
    
            public bool MyProperty
            {
                get
                {
                    return property;
                }
                set
                {
                    property = value;
                    RaisePropertyChanged("MyProperty");
                }
            }
        }
    }
