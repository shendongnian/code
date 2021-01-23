    private void txtbox1_DoubleClick(object sender, EventArgs e)
    {
        ShowTextboxMessage();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        ShowTextboxMessage();
    }
    
    private void ShowTextboxMessage()
    {
        MessageBox.Show(txtbox1.Text);
    }
