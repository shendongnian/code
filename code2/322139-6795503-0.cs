    private async void SelectExcelFile()
    {
        var dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.DefaultExt = ".xls|.xlsx";
        dlg.Filter = "Excel documents (*.xls, *.xlsx)|*.xls;*.xlsx";
        if (dlg.ShowDialog() == true)
        {
            await Task.Factory.StartNew(() => ReadExcelFile(dlg.FileName));
        }
    }
    private void ReadExcelFile(string fileName)
    {
       try
        {
            using (var conn = new OleDbConnection(string.Format(@"Provider=Microsoft.Ace.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", fileName)))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT DISTINCT [File Number] FROM [Sheet1$]", conn);
                var dt = new DataTable();
                // Line that causes the problem
                da.Fill(dt);
                FileContents = new List<int>() { 1, 2, 3 };
                // Does NOT update the UI even though CanExecute gets evaluated at True after this runs
                // OnPropertyChanged("SaveCommand");
                // Forces the Command to rebuild which correctly updates the UI
                SaveCommand = null;  
            }
       }
        catch (Exception ex)
        {
            MessageBox.Show("Unable to read contents:\n\n" + ex.Message, "Error");
        }
    }
    private ICommand _saveCommand;
    public ICommand SaveCommand
    {
        get 
        {
            if (_saveCommand == null)
                _saveCommand = new RelayCommand(Save, () => (FileContents != null && FileContents.Count > 0));
            // This runs after ReadExcelFile and it evaluates as True in the debug window!
            Debug.WriteLine("SaveCommand: CanExecute = " + _saveCommand.CanExecute(null).ToString());
            return _saveCommand;
        }
        set
        {
            if (_saveCommand != value)
            {
                _saveCommand = value;
                OnPropertyChanged("SaveCommand");
            }
        }
    }
