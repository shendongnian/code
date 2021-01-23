    private void button1_Click(object sender, EventArgs e)
    {
        listView1.Items.Clear();
    
        int step = 240 / comboBox1.SelectedIndex;
    
        for (int i = 0; i < 240; i += step)
        {
            HSLColor color = new HSLColor((double)i, 240, 120);
            listView1.Items.Add(i.ToString()).BackColor = color;
        }               
    }
