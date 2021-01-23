    private void buttonStart_Click(object sender, EventArgs e)
    {
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        client.SendCompleted += new System.Net.Mail.SendCompletedEventHandler(client_SendCompleted);
        client.SendAsync("from@here.com", "to@there.com", "subject", "body", null);
    }
    
    void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Error != null)
            MessageBox.Show("Successful");
        else
            MessageBox.Show("Error");
    }
