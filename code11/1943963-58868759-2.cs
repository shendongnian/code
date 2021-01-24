    public partial class MainWindow : Window
    {
        OpenFileDialog dialog = new OpenFileDialog();
        public ObservableCollection<FileName> fileNames = new ObservableCollection<FileName>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
        }
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Nullable<bool> result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                foreach(string filename in dialog.FileNames)
                {
                    FileName fileName = new FileName() { originalFileName = filename };
                    fileNames.Add(fileName);
                }
                
                DataGridFileNames.DataContext = fileNames;
            }
        }
        private void InitializeOpenFileDialog()
        {
            this.dialog.Multiselect = true;
        }
    }
