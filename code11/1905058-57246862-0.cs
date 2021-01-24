public partial class MainWindow : Window
       {
        ButtonFunctions buttonFunctions = new ButtonFunctions();
        public static MainWindow AppWindow;
        public MainWindow()
        {
            InitializeComponent();
            ProgressBar ProgBar = new ProgressBar();
            AppWindow = this;
        }
        public void Addtext(string t)
        {
            textBlock.Text += t;
        }
       }
Then in another class, I just invoke this method.
MainWindow.AppWindow.Addtext("\nConnection to server started...\n");
Hope this helps anyone with the same problem.
