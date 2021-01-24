    public partial class MainWindow : Window
    {
        private string count_path;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void FilesCountNumberShow_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(count_path))
            {
                MessageBox.Show("You must select a folder first!");
            }
            else
            {
                // Try to count nu,ber of files in folder
                int fCount = Directory.GetFiles(count_path, "*", SearchOption.TopDirectoryOnly).Length;
                FilesCountNumber_Label.Content = "Files in folder: " + fCount;
            }
        }
        private void SelectFolderPath_button_Click(object sender, RoutedEventArgs e)
        {
            // These code is for open File Dialog and choose older path as count_path
            var SelectFolderPath_Dialog = new WinForms.FolderBrowserDialog();
            if (SelectFolderPath_Dialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                count_path = SelectFolderPath_Dialog.SelectedPath;
                MessageBox.Show(count_path);
            }
        }
    }
