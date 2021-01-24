static void Main(string[] args)
{
    FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = "C:/some/directory/to/watch";
    watcher.NotifyFilter = NotifyFilters.LastAccess |
                           NotifyFilters.LastWrite  | 
                           NotifyFilters.FileName   | 
                           NotifyFilters.DirectoryName;
    watcher.Filter = "*.*";
    watcher.Deleted += new FileSystemEventHandler(OnDeleted);
    watcher.EnableRaisingEvents = true;
}
private static void OnDeleted(object sender, FileSystemEventArgs e)
{
    throw new NotImplementedException();
}
