    private StreamWriter file = null;
    public void button1_Click(object sender, EventArgs e)
    {
        button1.Visible = false;
        button2.Visible = true;
        if (file == null)
            file = new StreamWriter("test.txt");
        file.WriteLine(value.ToString());
    }
    private void button2_Click(object sender, EventArgs e)
    {
        button1.Visible = true;
        button2.Visible = false;
        if (file is object) 
            file.Close();
    }
