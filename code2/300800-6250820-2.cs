    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // don't close just yet if we click on x
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
