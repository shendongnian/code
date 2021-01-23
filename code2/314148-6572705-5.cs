    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        ViewDiskModel model = this.ContentPanel.DataContext as ViewDiskModel;
        if(model.Files.Any(file => file.IsSelected))
        {
            model.DeleteSelectedFiles.Execute(null);
            MessageBox.Show("Files Successfully Deleted.");
        }
        else
        {
            MessageBox.Show("Please select files to delete.");
        }
    }
