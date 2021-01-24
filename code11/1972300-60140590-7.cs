    public partial class MainWindow : UserControl
    {
        MyProgram.MVVM mvvm = new MyProgram.MVVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvvm;
        }
    
        protected void entryName_TextChanged(object sender, TextChangedEventArgs e)
        {
          mvvm.IsShowFrame = false;
        }
    
    }
