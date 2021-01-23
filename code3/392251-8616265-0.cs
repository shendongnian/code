    BackgroundWorker _worker;
    void Form_Load(object sender, EventArgs e)
    {
        _worker = new BackgroundWorker();
        _worker.DoWork += _worker_DoWork;
        _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        _worker.ProgressChanged +=_worker_ProgressChanged;
        _worker.WorkerReportsProgress = true;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        _worker.RunWorkerAsync(file);//pass on the file name
    }
    private void _worker_DoWork(object sender, DoWorkEventArgs e)
    {
        var file = e.Argument as String;
        using (StreamReader sr = new StreamReader(file, Encoding.ASCII))
        {
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                _worker.ReportProgress(line.Length);
            }
        }
    }
    private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //Report porogress bar change
        UpdateProgressBar(e.ProgressPercentage);
    }
    private void _worker_RunWorkerCompleted(object sender, 
                                       RunWorkerCompletedEventArgs e)
    {
        //do any stuff you want after reading the file.
    }
