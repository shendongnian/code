    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex > -1)
        {
            listBox2.SelectedIndex = -1;
            listBox3.SelectedIndex = -1;
        }
    }
    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox2.SelectedIndex > -1)
        {
            listBox1.SelectedIndex = -1;
            listBox3.SelectedIndex = -1;
        }
    }
    private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox3.SelectedIndex > -1)
        {
            listBox1.SelectedIndex = -1;
            listBox2.SelectedIndex = -1;
        }
    }
