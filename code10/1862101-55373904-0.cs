c#
class YourClass
{
    private FileSystemWatcher _watcher;
    // You want to only once initialize the FSW, hence we do it in the Constructor
    public YourClass()
    {    
         _watcher = new FileSystemWatcher(path_textBox.Text);
         //the renaming of files or directories.
		 watcher.NotifyFilter = NotifyFilters.LastAccess
		 					 | NotifyFilters.LastWrite
		 					 | NotifyFilters.FileName
		 					 | NotifyFilters.DirectoryName;
 
		 watcher.Renamed += new RenamedEventHandler(OnRenamed);
		 watcher.Error += new ErrorEventHandler(OnError);
		 watcher.EnableRaisingEvents = true;
    }
    private void renameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Replace 'selectedFile' and 'newFilename' with the variables
        // or values you want (probably from the GUI)
        System.IO.File.Move(selectedFile, newFilename);
    }
    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        // Do whatever
        MessageBox.Show($"File: {e.OldFullPath} renamed to {e.FullPath}");
    }
    // Missing the implementation of the OnError event handler
}
