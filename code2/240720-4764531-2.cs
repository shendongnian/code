    private void Button1Click(object sender, EventArgs e)
    {
        var x = int.Parse(textBox1.Text);
        var y = int.Parse(textBox2.Text);
    
        textBox3.Text = (x + y).ToString();
    }
