    BackgroundWorker worker = sender as BackgroundWorker;
    bool go = true;
    while(go)
    {
        for (int i = listBox1.Items.Count - 1; i >= 0; i--)
        {
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    go = false;
                    break;
                }
                else
                {
                    string queryhere = listBox1.Items[i].ToString();
                    this.SetTextappend("" + queryhere + "\n");
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i * 1);
                }
            }
        }
    }
