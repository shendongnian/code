    DataTable pingResults = new DataTable();
    List<string> ipAddress = new List<string>();
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            pingResults.Clear();
            ipAddress.Add("10.100.1.1");
            ipAddress.Add("10.100.1.2");
            ipAddress.Add("10.100.1.3");
            ipAddress.Add("10.100.1.4");
            ipAddress.Add("10.100.1.5");
            ipAddress.Add("10.100.1.100");
            List<PictureBox> pictureBoxList = new List<PictureBox>();
            for (int i = 1; i < 7; i++)
            {
                pictureBoxList.Add((PictureBox)Controls.Find("pictureBox" + i, true)[0]);
            }
            Parallel.For(0, ipAddress.Count(), (i, loopState) =>
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(ipAddress[i].ToString());
                this.BeginInvoke((Action)delegate()
                {
                    pictureBoxList[i].BackColor = (pingReply.Status == IPStatus.Success) ? Color.Green : Color.Red;
                });
            });
        }
    private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
