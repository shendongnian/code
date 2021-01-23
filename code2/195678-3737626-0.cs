    [STAThread]
    static void Main(string[] args)
    {
        string file = "temp.txt";
        ReadFile(file);
        FileSystemWatcher fswatcher = new FileSystemWatcher(".\\");
        fswatcher.Changed += delegate(object sender, FileSystemEventArgs e)
                                 {
                                     ReadFile(e.FullPath);
                                 };
        while (true)
        {
            fswatcher.WaitForChanged(WatcherChangeTypes.Changed);
        }
    }
    private static void ReadFile(string file)
    {
        Stream stream = File.OpenRead(file);
        StreamReader streamReader = new StreamReader(stream);
        string str = streamReader.ReadToEnd();
        MessageBox.Show(str);
        streamReader.Close();
        stream.Close();
    }
