    string alphaBeta = @"Alpha\Beta";
    public Form1()
    {
        InitializeComponent();
        Directory.CreateDirectory(alphaBeta);
        FileSystemWatcher watcher = new FileSystemWatcher()
        {
            Path = alphaBeta,
            Filter = "*.dat",
            NotifyFilter = NotifyFilters.FileName
        };
        watcher.EnableRaisingEvents = true;
        watcher.Dispose();
        File.WriteAllText(alphaBeta + @"\Gamma.dat", "Delta");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Directory.Delete("Alpha", true);//Recursively Delete
    }
