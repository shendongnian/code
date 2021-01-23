    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {    
            BackgroundWorker worker = sender as BackgroundWorker;
            while (worker.CancellationPending != true)
            {
                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                {
                       if(worker.CancellationPending != true)
                       {
                          string queryhere = listBox1.Items[i].ToString();
                          this.SetTextappend("" + queryhere + "\n");
                          System.Threading.Thread.Sleep(500);
                          worker.ReportProgress(i * 1);
                       }
                       else
                       {
                          break;
                       } 
                }
            }
            e.Cancel = true;
        }
                       
  
