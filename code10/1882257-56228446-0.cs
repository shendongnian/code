    public partial class MainWindow : Window
    {
        FolderBrowserDialog folderBrowserDialog = null;
        List<string> filesToSave = null;
        public MainWindow()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
            filesToSave = new List<string>
            {
                "A.txt",
                "B.txt",
                "C.txt"
            };
        }
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var file in filesToSave)
            {
                var path = Path.Combine(TxtFolderPath.Text, file);
                File.WriteAllText(path, string.Format("Contents of {0}", file));
            }
        }
    }
