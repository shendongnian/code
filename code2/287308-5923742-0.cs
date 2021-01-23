    private void OK_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
