    Form2 f2 = null;
    Form3 f3 = null;
    
    private void Form1_Load(object sender, EventArgs e)
    {
        f2 = new Form2();
        f2.Show();
    
        f3 = new Form3();
        f3.Show();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        if (f2.Visible)
        {
            f2.Hide();
        }
        else
        {
            f2.Show();
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        if (f3.Visible)
        {
            f3.Hide();
        }
        else
        {
            f3.Show();
        }
    }
