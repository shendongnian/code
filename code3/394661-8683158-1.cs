    public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
            }
               
            private String m_DelayedText;
            public String DelayedText 
            {
                get
                {
                    return m_DelayedText;
                }
                set
                {
                    if (m_DelayedText != value)
                    {
                        String delayedText;
                        m_DelayedText = delayedText = value;
                        Task.Factory.StartNew(() =>
                            {
                                Thread.Sleep(2000);
                                if (delayedText == m_DelayedText)
                                {
                                    RaisePropertyChanged("DelayedText");
                                }
                            });
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(String _Prop)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(_Prop));
                }
            }
        }
