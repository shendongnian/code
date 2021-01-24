    public partial class MainWindow : Window
        {
            public static ObservableCollection<oToevoegen> oc { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                oc = new ObservableCollection<oToevoegen>();
                this.lstFinanceInfo.ItemsSource = oc;
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
    
                oc.Add(new oToevoegen() { Name = "Name1" });
    
                Window1 w1 = new Window1();
                w1.Show();
            }
        }
