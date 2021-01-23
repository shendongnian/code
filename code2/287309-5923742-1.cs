    private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.DialogResult == DialogResult.OK)
        {
            e.Cancel = !ValidateInput();
        }
    }
