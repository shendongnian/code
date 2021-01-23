    public partial class FileListView: Window
    {
      private FileListViewModel  _ fileListViewModel = new FileListViewModel ();
      public FileListViewModel () 
      {
        InitializeComponent();
        base.DataContext = _fileListViewModel; 
      }
    }
