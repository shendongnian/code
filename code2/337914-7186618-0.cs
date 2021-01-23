    private void txtbox1_DoubleClick(object sender, EventArgs e)
    {
        button1_Click(sender, e);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(txtbox1.Text);
    }
