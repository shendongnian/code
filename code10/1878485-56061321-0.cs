    async void MyButtonClick(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        var folders = btn.Name.Equals("test") 
            ? _model.Folders.ToArray()
            : fileDataGrid.SelectedItems.Cast<FolderStatus>().ToArray();"
        foreach (var folder in folders)
        {
            // This will be executed on the UI thread
            _model.Message = $"This is message for {folder.Name}"};
            _model.IsBusy = true;
            // This will be executed on a worker thread due to Task.Run
            await Task.Run(() => YourLongRunningOperation(folder));
            await Task.Run(() => SomeOtherLongRunningOperation());
            // This will be executed again on the UI thread
            _model.IsBusy = false;
        }
    }
