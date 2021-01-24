     public partial class MainWindow : Window
        {
        public RelayCommand ButtonClickCommand { get; set; }
        public MainWindow()
        {
        InitializeComponent();
        ButtonClickCommand= new RelayCommand(MyButtonClickExcute);
        }
        private void MyButtonClickExcute()
        {
        UserControl1 userControl1 = new UserControl1 {Width = 50, Height = 50,CloseAction = RemoveUserControlFromPanel };
        Panel.SetZIndex(userControl1, 10);
        MainGrid.Children.Add(userControl1);
        }
        public void RemoveUserControlFromPanel(UserControl1 userControl1)
        {
        MainGrid.Children.Remove(userControl1);
        }
        }
