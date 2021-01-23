    private void ParameterForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
