     private async void Button_Click(object sender, RoutedEventArgs e)
     {
        bool success = await FileHelper.MoveFileAsyncWithProgress("FILETOMOVE", "DestinationFilePath");
     }
     // This is called when progress changes, if file is small, it
     // may not even hit this.
     private void FileHelper_OnProgressChanged(double percentage)
     {
            Application.Current.Dispatcher.Invoke(() =>
            {
                pbProgress.Value = percentage;
            });
     }
     // This is called after a move, whether it succeeds or not
     private void FileHelper_OnComplete(bool completed)
     {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show("File process succeded: " + completed.ToString());
            });
     }
