        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker.DoWork += (s, e) =>
            {
                test.RunTests();
            };
            backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                ShowCompleteMessage();
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RunAlgorithmTests();
        }
        //this is called from an onclick method
        private void RunAlgorithmTests()
        {
            backgroundWorker.RunWorkerAsync();        
        }
