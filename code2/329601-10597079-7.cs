        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
                ftp.Mirror(@"C:\LocalFolder", "/RemoteFolder", 10));
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    lbPercentSuccess.Dispatcher.Invoke(new Action(() =>
                    {
                        lbPercentSuccess.Content = ftp.FtpProgress.SuccessPercentage;
                        lbPercentError.Content = ftp.FtpProgress.ErrorPercentage;
                        lbPercentTotal.Content = ftp.FtpProgress.TotalPercentage;
                        lbDuration.Content = ftp.FtpProgress.Duration;
                    }));
                    Thread.Sleep(500);
                }
            });
        } 
