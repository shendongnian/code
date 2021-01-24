    private List<string> filesToIgnore = new List<string>();
    private void OnCreated(object source, FileSystemEventArgs file)
    {
       filesToIgnore.Add(file.Name);
    }
    private void OnChanged(object source, FileSystemEventArgs file)
    {
        if(filesToIgnore.Contains(file.Name))
        {
             filesToIgnore.Remove(file.Name);
             return; 
        }
        
        // Code to execute when user saves the file
    }
