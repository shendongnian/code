        private void buttonRename_Click(object sender, EventArgs e)
        {
             backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (ListViewItem myitem in listView.Items)
                {
                     try
                     {
                           //Rename
                     }
                     catch
                     {
                     }
                }    
         }
