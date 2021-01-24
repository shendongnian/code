    if (e.CloseReason == CloseReason.UserClosing)
    {
        DialogResult result = MessageBox.Show("Sure?", "Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        if (result.Equals(DialogResult.OK))
        {
            Environment.Exit(0);
        }
        else
        {
            e.Cancel = true;
        }
    }
