    public MyWindow()
    {
       InitializeComponent();
    
       FolderWatcher = new FolderList(...);
    
       ProjectCombo.ItemsSource = FolderWatcher.Folders;
    }
