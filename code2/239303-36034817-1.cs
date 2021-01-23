     private void updateUiWhenDoneWithPayment_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(30000);
            while (string.IsNullOrEmpty(GetAuthToken()) && !((BackgroundWorker)sender).CancellationPending)
            {
                Thread.Sleep(5000);
            }
            //Plug in pooling mechanism
            this.AuthCode = GetAuthToken();
        }
