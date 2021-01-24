       private void button1_Click(object sender, EventArgs e)
    
            {
                if (radioButton1.Checked)
                {
                    Thread thread = new Thread(() =>
                    {
                        WebClient client = new WebClient();
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        client.DownloadStringCompleted += Client_DownloadStringCompleted;
                        client.DownloadStringAsync(new Uri("https://pastebin.pl/view/raw/sample"));
                    });
                    thread.Start();
                }
            }
    
            private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
            {
                this.BeginInvoke((MethodInvoker)delegate {
                    textBox1.Text = e.Result;// "Completed";
                });
            }
    
            void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                this.BeginInvoke((MethodInvoker)delegate {
                    double bytesIn = double.Parse(e.BytesReceived.ToString());
                    double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                    double percentage = bytesIn / totalBytes * 100;
                    textBox1.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                    progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
                });
            }
