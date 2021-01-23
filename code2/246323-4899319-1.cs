     private void button1_Click(object sender, EventArgs e)
     {
         using (FolderBrowserDialog dlg2 = new FolderBrowserDialog())
         {
           if (dlg2.ShowDialog() == DialogResult.OK)           
           {
              backgroundWorker1.RunWorkerAsync(dlg2SelectedPath);
           }
        }
     }
    
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        string selectedpath = (string) e.Args;
        ....
    }
