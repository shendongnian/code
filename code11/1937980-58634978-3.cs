    using System.ComponentModel;
    using System.Windows;
    namespace StackoverflowTest
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            bool _checked = true;
            public bool Checked
            {
                get
                {
                    return _checked;
                }
                set
                {
                    _checked = value;
                    RaisePropertyChanged(nameof(Checked));
                }
            }
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void RaisePropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
