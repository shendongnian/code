    public partial class AddTask : Window
    {
    
        public List<string> ListExtension { get; } = new List<string>();
        public SeqSave SqSv1 { get; }= new SeqSave();
        public AddTask()
        {
            InitializeComponent();
        }
        private void GetSourcePath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog sourcePath = new FolderBrowserDialog();
            DialogResult result = sourcePath.ShowDialog();
            string strSourcePath = sourcePath.SelectedPath;
            SqSv1.srcPathList.Add(strSourcePath);
    
            DirectoryInfo dirInfo = new DirectoryInfo(strSourcePath);
            foreach (FileInfo f in dirInfo.GetFiles())
            {
               if (!ListExtension.Contains(f.Extension))
               {
                   ListExtension.Add(f.Extension);
               }
            }
    
            for(int i = 0; i < ListExtension.Count; i++)
            {
                lstB1.Items.Add(ListExtension[i]);
            }
        }
    
        private void GetDestinationPath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog destinationPath = new FolderBrowserDialog();
            DialogResult result = destinationPath.ShowDialog();
            string strDestinationPath = destinationPath.SelectedPath;
            SqSv1.dstPathList.Add(strDestinationPath);
        }
    
        private void Encrypt(object sender, RoutedEventArgs e)
        {
    
        }
        private void Return(object sender, RoutedEventArgs e)
        {
    
        }
    
        private void Confirm(object sender, RoutedEventArgs e)
        {
            SqSv1.savedNamesList.Add(taskNameProject.Text);
    
            if (RadioButton1.IsChecked == true)
            {
                SqSv1.saveTypeList.Add("1");
    
            }else if(RadioButton2.IsChecked == true)
            {
                SqSv1.saveTypeList.Add("2");
            }
            if (Checkbox1.IsChecked == true)
            {
                SqSv1.didBackupList.Add(true);
            }
            else
            {
                SqSv1.didBackupList.Add(false);
            }
            MessageBox.Show("Task successfully added.");
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
