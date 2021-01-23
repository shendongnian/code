    private void lstView_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        upButton.Enabled = lstView.SelectedIndex > 0;
        downButton.Enabled = lstView.SelectedIndex < lstView.Items.Count - 1;
    }
