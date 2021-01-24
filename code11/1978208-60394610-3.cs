    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DataGrid1.SelectAllCells();
        DataGrid1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
        ApplicationCommands.Copy.Execute(null, DataGrid1);
        DataGrid1.UnselectAllCells();
        string result = (string)Clipboard.GetData(DataFormats.Text);
        using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + "AllCustomersCSV.txt",
            false, Encoding.UTF8))
            foreach (char c in result)
                if (c != '\t')
                    sw.Write(c);
                else
                    sw.Write(",");
    }
