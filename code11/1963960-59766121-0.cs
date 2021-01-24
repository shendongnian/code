    private void button1_Click(object sender, EventArgs e)
    {
    	ResourceManager rm = new System.Resources.ResourceManager(typeof(Form1));
    	textBox1.Text = rm.GetString("string1").ToString();
    }
