    void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
            MessageBox.Show("Successful");
        else if (e.Error is SmtpException)
        {
            if ((e.Error as SmtpException).Message.Contains("secure connection"))
            {
                (e.UserState as SmtpClient).EnableSsl = true;
                (e.UserState as SmtpClient).SendAsync(objMailMsg, e.UserState);
            }
            else
                MessageBox.Show("Error: " + e.Error.ToString());
        }
        else
            MessageBox.Show("Error: " + e.Error.ToString());
    }
