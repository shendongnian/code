    private void DoWork(object sender, DoWorkEventArgs e)
    {
       // get a handle on the worker that started this request
       BackgroundWorker workerSender = sender as BackgroundWorker;
       // get a node list from agrument passed to RunWorkerAsync
       XmlNodeList node = e.Argument as XmlNodeList;
       for (int i = 0; x < node.Count; i++)
       {
           textBox2.Text = node[i].InnerText;
           workerSender.ReportProgress(node.Count / i);
       }
    }
    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // do something after work is completed     
    }
    public void ProgressChanged( object sender, ProgressChangedEventArgs e )
    {
        progressBar.Value = e.ProgressPercentage;
    }
