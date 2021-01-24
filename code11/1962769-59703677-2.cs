       private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Download(new Uri("https://pastebin.pl/view/raw/sample"));
            }
            else if (radioButton2.Checked)
            {
                Download(new Uri("https://pastebin.pl/view/raw/sample2"));
            }
            else if (radioButton3.Checked)
            {
                Download(new Uri("https://pastebin.pl/view/raw/sample4"));
            }
            else
            {
                MessageBox.Show(this, "select radio btn");
            }
        }
        private void  Download(Uri uri)
        {
            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += Client_DownloadProgressChanged1;
                client.DownloadStringCompleted += Client_DownloadStringCompleted;
                client.DownloadStringAsync(uri);
            });
            thread.Start();
        }
        private void Client_DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                if(percentage >=10 && percentage <50)
                { 
                  textBox1.Text ="message for 10%";   
                }
                else if if(percentage >=50 && percentage <100)
                {
                        textBox1.Text ="message for 50%";
                }
                else
                {
                  textBox1.Text ="completed";
                }
                // you can use to show to calculated % of download
            });
        }
        
        private  void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                var accounts = e.Result.Split('\n');
                textBox1.Text = accounts[new Random().Next(0,accounts.Length)];
            });
        }
