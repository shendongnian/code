    CsvGrid.Items.Refresh();
    CsvGrid.UpdateLayout();
    
    for (int i = 0; i < CsvGrid.Columns.Count; i++)
    {
        foreach (var checkBox in CheckBoxes.Children.OfType<CheckBox>().Where(x => x.IsChecked == true))
        {
            if (CsvGrid.Columns[i].Header.ToString() == checkBox.Tag.ToString()) CsvGrid.Columns.RemoveAt(i);
         }
    }
    
    CsvGrid.SelectAllCells();
    CsvGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
    ApplicationCommands.Copy.Execute(null, CsvGrid);
    String result = (string) Clipboard.GetData(DataFormats.Text);
    CsvGrid.UnselectAllCells();
    
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.FileName = "Document";
    saveFileDialog.DefaultExt = ".xls";
    saveFileDialog.Filter = "Excel|*.xls|Excel 2010|*.xlsx|CSV files (*.csv)|*.CSV";
    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    if (saveFileDialog.ShowDialog() == true)
    {
        File.WriteAllText(saveFileDialog.FileName, result.Replace(',', ' '));
        MessageBox.Show("File created!");
    }
