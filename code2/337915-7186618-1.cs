    private void txtbox1_DoubleClick(object sender, EventArgs e)
    {
        ShowMessageBox();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        ShowMessageBox();
    }
    private void ShowMessageBox()
    {
        MessageBox.Show(txtbox1.Text);
    }
