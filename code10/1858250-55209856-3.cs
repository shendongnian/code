    private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.Tag != null)
        {
            // Button clicked
        }
        else
        {
            // other reasons
            // Dp not call Close here, you are already closing 
            // if you don't set e.Cancel = true;
        }
    }
