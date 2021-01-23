    //this method you will get after you double click the ComboBox in the Form       
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex > 0)
        {
            comboBox1.Click += new EventHandler(this.IWantToDisplayMessageBox);
        }
    }
    public void IWantToDisplayMessageBox(object sender, EventArgs e)
    {
        MessageBox.Show("student ID and email");
    }
