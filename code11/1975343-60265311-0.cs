    public static void Run()
    {
        MySqlConnection mcon = new MySqlConnection("server=WINX-PC04;user id=root;password=GS201706;database=technical");
        MySqlDataReader myreader = null;
        MySqlCommand cmd = new MySqlCommand("select * from files", mcon);
        mcon.Open();
        myreader = cmd.ExecuteReader();
        List<String> list = new List<String>();
        while (myreader.Read())
        {
            list.Add(myreader[1].ToString());
        }
        mcon.Close();
        foreach (string i in list)
        {
            Console.WriteLine(i);
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName($@"{i}");
            watcher.Filter = Path.GetFileName($@"{i}");
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Created += directoryChange;
            watcher.Deleted += directoryChange;
            watcher.Renamed += onRename;     
        }
        Console.Read(); // Likethis
    }   
