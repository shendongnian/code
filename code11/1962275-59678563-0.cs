    private void Form1_Load(object sender, EventArgs e)
    {
        textBox1.Text =  Properties.Settings.Default.LastText
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.LastText = textBox1.Text;
        Properties.Settings.Default.Save();
    }
