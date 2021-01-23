    public List<string> MapMyFiles()
    {
        List<FileInfo> batchaddresses = new List<FileInfo>();
        foreach (object o in lstViewAddresses.Items)
        {
            DirectoryInfo di = new DirectoryInfo(o);
            if (!di.Exists && MessageBox.Show(o.ToString() + " does not exist. Process anyway?", "Continue?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                Application.Exit();
            (new List<string>(new[]{ "*-E.esy", "*p-.csv" })).ForEach(filter => {
                (new List<string>(di.GetFiles(filter))).ForEach(file => {
                    batchaddresses.Add(new FileInfo(file));
                });
            });
        }
            
        return batchaddresses.OrderBy(f => f.CreationTime).Select(f => f.FullName).ToList();
    }
