    private void SelectFile()
    {
        var dlg = new OpenFileDialog();
        dlg.DefaultExt = this.Extension;
        dlg.Filter = this.Filter;
        if (dlg.ShowDialog() == true)
        {
            var file = new FileInfo(dlg.FileName);
            FileName = file.FullName;
            if (ProcessFileDelegate != null)
                ProcessFileDelegate()
        }
    }
