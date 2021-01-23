    // Create a "Save As" dialog for selecting a directory (HACK)
    var dialog = new Microsoft.Win32.SaveFileDialog();
    dialog.InitialDirectory = textbox.Text; // Use current value for initial dir
    dialog.Title = "Select a Directory"; // instead of default "Save As"
    dialog.Filter = "Directory|*.this.directory"; // Prevents displaying files
    dialog.FileName = "select"; // Filename will then be "select.this.directory"
    if (dialog.ShowDialog() == true) {
        string path = dialog.FileName;
        // Remove fake filename from resulting path
        path = path.Replace("\\select.this.directory", "");
        path = path.Replace(".this.directory", "");
        // If user has changed the filename, create the new directory
        if (!System.IO.Directory.Exists(path)) {
            System.IO.Directory.CreateDirectory(path);
        }
        // Our final value is in path
        textbox.Text = path;
    }
