    public List<string> MapMyFiles()
    {
        List<FileInfo> batchaddresses = new List<FileInfo>();
        foreach (object o in lstViewAddresses.Items)
        {
            try
            {
                string[] files = Directory.GetFiles(o.ToString(), "*-E.esy");
                files.ToList().ForEach(f => batchaddresses.Add(new FileInfo(f)));
            }
            catch { }
        }
        return batchaddresses.OrderBy(f => f.CreationTime).Select(f => f.FullName).ToList();
    }
