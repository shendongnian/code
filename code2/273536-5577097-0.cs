    private bool loggingOut;
    private void Form1_DoubleClick(object sender, EventArgs e)
    {
        this.loggingOut = true;
        this.Close();
        // This is optional as we are closing the form anyway
        this.loggingOut = false;
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing && !loggingOut)
        {
            // Handle form closing here
        }
    }
