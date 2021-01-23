    private void BtnFileOpen_Click(object sender, RoutedEventArgs e)
    {
        var fileDialog = new System.Windows.Forms.OpenFileDialog();
        var result = fileDialog.ShowDialog();
        switch (result)
        {
            case System.Windows.Forms.DialogResult.OK:
                var file = fileDialog.FileName;
                TxtFile.Text = file;
                TxtFile.ToolTip = file;
                break;
            case System.Windows.Forms.DialogResult.Cancel:
            default:
                TxtFile.Text = null;
                TxtFile.ToolTip = null;
                break;
        }
    }
