    private void button1_Click(object sender, System.EventArgs e)
    {
        int ec;
        ec=elRefManager.CheckReferences(null, new string[] {textBox1.Text});
    
        if (ec<0)
            MessageBox.Show("An error occurred adding this reference");
        if (ec>0)
            MessageBox.Show("Could not add " + textBox1.Text + 
                        "\nCheck its spelling and try again");
    }
