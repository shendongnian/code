    DialogResult result = MessageBox.Show("Click yes to close, otherwise click no.", "Message Box Test", MessageBoxButtons.YesNo);
    if (result == DialogResult.Yes)
    {
      Application.Exit();
    }
