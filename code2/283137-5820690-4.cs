    namespace WpfApplication1
    {
        using System.ComponentModel;
        using System.Windows;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
            }
    
            private Thickness pagePadding;
    
            public Thickness PagePadding
            {
                get
                {
                    return this.pagePadding;
                }
                set
                {
                    this.pagePadding = value;
                    this.Changed("PagePadding");
                }
            }
    
            private void Changed(string name)
            {
                var handlers = this.PropertyChanged;
                if (handlers != null)
                {
                    handlers.Invoke(this, new PropertyChangedEventArgs(name));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
