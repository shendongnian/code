    public partial class AddTask : Window
    {
    
        public List<string> listExtension = new List<string>();
        public SeqSave sqSv1 = new SeqSave();
        public AddTask()
        {
            InitializeComponent();
        }
        private void GetSourcePath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog sourcePath = new FolderBrowserDialog();
            DialogResult result = sourcePath.ShowDialog();
            string strSourcePath = sourcePath.SelectedPath;
            sqSv1.srcPathList.Add(strSourcePath);
    
            DirectoryInfo dirInfo = new DirectoryInfo(strSourcePath);
            foreach (FileInfo f in dirInfo.GetFiles())
            {
               if (!listExtension.Contains(f.Extension))
               {
                   listExtension.Add(f.Extension);
               }
            }
    
            for(int i = 0; i < listExtension.Count; i++)
            {
                lstB1.Items.Add(listExtension[i]);
            }
        }
    
        private void GetDestinationPath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog destinationPath = new FolderBrowserDialog();
            DialogResult result = destinationPath.ShowDialog();
            string strDestinationPath = destinationPath.SelectedPath;
            sqSv1.dstPathList.Add(strDestinationPath);
        }
    
        private void Encrypt(object sender, RoutedEventArgs e)
        {
    
        }
        private void Return(object sender, RoutedEventArgs e)
        {
    
        }
    
        private void Confirm(object sender, RoutedEventArgs e)
        {
            sqSv1.savedNamesList.Add(taskNameProject.Text);
    
            if (RadioButton1.IsChecked == true)
            {
                sqSv1.saveTypeList.Add("1");
    
            }else if(RadioButton2.IsChecked == true)
            {
                sqSv1.saveTypeList.Add("2");
            }
            if (Checkbox1.IsChecked == true)
            {
                sqSv1.didBackupList.Add(true);
            }
            else
            {
                sqSv1.didBackupList.Add(false);
            }
            MessageBox.Show("Task successfully added.");
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
