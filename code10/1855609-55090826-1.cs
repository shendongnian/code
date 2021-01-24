    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (var file in System.IO.Directory.GetFiles(@"c:\"))
        {
            listBox1.Items.Add(file);
        }
    }
    
    
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox1.SelectedItem != null)
        {
            textBox1.Text = System.IO.File.ReadAllText(listBox1.SelectedItem.ToString());
        }
    }
