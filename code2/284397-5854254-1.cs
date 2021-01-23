    MessageBoxButtons[] mbs = new[] {
        MessageBoxButtons.AbortRetryIgnore,
        MessageBoxButtons.OK,
        MessageBoxButtons.OKCancel,
        MessageBoxButtons.RetryCancel,
        MessageBoxButtons.YesNo,
        MessageBoxButtons.YesNoCancel
    };
    
    MessageBoxIcon[] mbi = new[] {
        MessageBoxIcon.Asterisk,
        MessageBoxIcon.Error,
        MessageBoxIcon.Exclamation,
        MessageBoxIcon.Hand,
        MessageBoxIcon.Information,
        MessageBoxIcon.None,
        MessageBoxIcon.Question,
        MessageBoxIcon.Stop,
        MessageBoxIcon.Warning
    };
    
    MessageBox.Show("Message Text", "Message Title", mbs[2], mbi[4]);
