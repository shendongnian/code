    private void Form_FormClosed(object sender, FormClosingEventArgs e)
    {
        // if close button clicked, not the computer is being shutdown or anyother reason
        if (e.CloseReason == CloseReason.UserClosing)
        {
            Application.Exit();
        }
    }
