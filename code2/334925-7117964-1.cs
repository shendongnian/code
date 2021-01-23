    private void numFoobar_ValueChanged(object sender, EventArgs e)
    {
        this.ValidateChildren();
    }
    private void numFoobar_Validating(object sender, CancelEventArgs e)
    {
        if (MessageBox.Show("This will erase the entire document. Are you sure?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }
