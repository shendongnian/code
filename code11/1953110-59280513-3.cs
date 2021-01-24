        private void button1_Click(object sender, EventArgs e)
        {
            using (PleaseWait pw = new PleaseWait(MakeAzureSQLQuery))
            {
                pw.ShowDialog();
            }
        }
        private void MakeAzureSQLQuery()
        {
            //Making the Query Function
            //You can also use Background Thread for Querying
            for (int nCount = 0; nCount < 500; nCount++)
                Thread.Sleep(50);
        }
