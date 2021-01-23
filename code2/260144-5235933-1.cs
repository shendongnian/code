    public void SendEmailButtonClicked(object sender, EventArgs e)
    {
        // Make any changes to the UI here to disable whatever you want
        new Thread(SendEmail).Start();
    }
    private void SendEmail()
    {
        // Do the sending of the email here (this is in the non-UI thread)
        // Then afterwards, possibly in a finally block
        Action action = EmailSent;
        this.BeginInvoke(action);
    }
    private void EmailSent()
    {
        // Back in the UI thread, do whatever you need to indicate
        // success/failure, re-enable disabled parts of the UI etc
    }
