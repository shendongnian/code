    BackgroundWorker worker;
    
    public Parsser(BackgroundWorker bg)
        {
            worker = bg;
        }
    
    public void ParseTheFile()
    {
        Lines = File.ReadAllLines(FilePath);
        this.size = Lines.Length;
        foreach (string line in Lines)
        {
            worker.ReportProgress(allreadtchecked/size);
