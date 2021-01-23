        private void btnDownLoad_Click(System.Object sender, 
            System.EventArgs e)
        {
            // Start the asynchronous operation.
            backgroundWorkerDownLoadFile.RunWorkerAsync();
        }
        private void backgroundWorkerDownLoadFile_DoWork(object sender, 
            DoWorkEventArgs e)
        {   
            // Get the File in Server.
        }
