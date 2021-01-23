    private  void SelectExcelFile()
    {
        var dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.DefaultExt = ".xls|.xlsx";
        dlg.Filter = "Excel documents (*.xls, *.xlsx)|*.xls;*.xlsx";
    
        if (dlg.ShowDialog() == true)
        {
            Task.Factory.StartNew(() => ReadExcelFile(dlg.FileName));
        }
    }
    private List<int> _fileContents = new List<int>();
    
    public List<int> FileContents
    {
        get { return _fileContents; }
        set 
        {
            if (value != _fileContents)
            {
                _fileContents = value;
    
                this.Dispatcher.Invoke ( new Action (delegate() 
                {
                    button2.IsEnabled = true;
                    button2.Command = SaveCommand;
                }),null);
            }
        }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        button2.IsEnabled = false;
        button2.Command = null;
        SelectExcelFileCommand.Execute(null);
    }
    private void button2_Click(object sender, RoutedEventArgs e)
    {
        SaveCommand.Execute(null);
    }
