    public void Start()
    {
        FileSystemWatcher fsw = new FileSystemWatcher();
        fsw.Path = "\\server\share";  //or use your inputdir
        fsw.NotifyFilter = NotifyFilters.Size;  //(several others available)
        fsw.Filter = "*.jpg";
        fsw.Changed += new FileSystemEventHandler(OnChanged);
        fsw.EnableRaisingEvents = true;
    }
    private void OnChanged(object source, FileSystemEventArgs e)
    {
        //do stuff.
    }
