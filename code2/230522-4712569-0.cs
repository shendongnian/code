     private void BtnWatch_Click(object sender, EventArgs e)
        {
            tickerDelegate1 = new TickerDelegate(SetLeftTicker);
            Thread th = new Thread(new ThreadStart(DigitalTimer));
            th.IsBackground = true;
            th.Start();
           
        }
        private void SetLeftTicker()
        {
            label2.Text=DateTime.Now.ToLongTimeString();
        }
       
        public void DigitalTimer()
        {
            while (true)
            {
                label2.BeginInvoke(tickerDelegate1, new object[] {});
                Thread.Sleep(1000);
            }
        }
        private void BtnProgrss_Click(object sender, EventArgs e)
        {
           // progressBar1.Visible = true;
            if (_flag == true)
            {
                tickerDelegate1 += new TickerDelegate(AnimateProgBar);
                _flag = false;
            }
        }
        private void AnimateProgBar()
        {
           
           num += 5;
            if (num >= 100)
            {
                num = 0;
            }
            progressBar1.Value = num;
        }
        private void SetProgressBar()
        {
            
            while (true)
            {
 
                progressBar1.Invoke(tickerDelegate1, new object[] { });
                //Thread.Sleep(10);
            }
        }
