    private void button1_Click(object sender, EventArgs e)
    {
        Thread t = new Thread(new ParameterizedThreadStart(loop));
        t.Start(str);
    }
    
    private void loop(string str)
    {
        for (int i = 0; i < 100000; i++)
        {
            textBox1.Text = i + str;
        }
    }
