    private void button1_Click(object sender, EventArgs e)
    {
        button1.Text = "Button 1 Text";
        MessageBox.Show("B1 Function1");
        button1.Click -= button1_Click;
        button1.Click += button1_Click2;
    }
    private void button1_Click2(object sender, EventArgs e)
    {
        button.Text = "Button 1 Text 2";
        MessageBox.Show("B1 Function2");
        button1.Click -= button1_Click2;
        button1.Click += button1_Click;
    }
    
