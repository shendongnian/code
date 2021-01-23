    // your event args might include more properties
    public class ShowMessageBoxEventArgs : System.EventArgs
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    // example of your model base
    public class MyModelBase
    {
        public event EventHandler<ShowMessageBoxEventArgs> ShowMessageBox;
        protected void RaiseShowMessageBox(string title, string text)
        {
            if (ShowMessageBox == null)
                return;
            var _Args = new ShowMessageBoxEventArgs
            {
                Text = text,
                Title = title
            };
            ShowMessageBox(this, _Args);
        }
    }
    // for this sample, this is your view model
    public class MyModel : MyModelBase
    {
        public void DoSomething()
        {
            // TODO: Do Something
            base.RaiseShowMessageBox("DoSomething", "Complete!");
        }
    }
    // this is your window or in app.xaml.cs (where we do it)
    public partial class MainWindow : Window
    {
        MyModel m_MyModel = new MyModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = m_MyModel;
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        bool m_Loaded = false; // only once
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_Loaded)
                return;
            m_Loaded = true;
            // allow model to show messagebox
            m_MyModel.ShowMessageBox += (s, arg) =>
            {
                MessageBox.Show(arg.Text, arg.Title);
            };
        }
    }
