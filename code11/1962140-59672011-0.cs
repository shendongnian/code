    private void DataChanged(object sender, EventArgs e)
    {
        btnAdd.Enabled = !string.IsNullOrWhiteSpace(txtHighScore.Text)
            && !string.IsNullOrWhiteSpace(txtGamertag.Text);
    }
