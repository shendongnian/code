    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        string path = @"C:\SMS";
        while (!e.Result)
        {
            e.Result = Directory.GetFiles(path).Any();
        }
    }
    
