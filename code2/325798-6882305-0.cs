        void Send()
        {
            SmtpClient client = new SmtpClient();
            client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
            client.SendAsync(/* METHOD's PARAMS */);
        }
        void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled)
            {
                // TODO : Report error
            }
        }
