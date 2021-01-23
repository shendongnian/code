    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GroupBox g = new GroupBox();
            g.MouseLeftButtonUp += new MouseButtonEventHandler(g_MouseLeftButtonUp);
            MainGrid.Children.Add(g);
        }
        void g_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Debugger.Break();
        }
    }
