    if(textBox1.Text.Length > 2)
    {
    int acceptednumber = Convert.ToInt32(textBox1.Text);
    if(acceptednumber < 0)
    {
    textBox1.Text = "";
    MessageBox.Show("-ve values are not allowed");
    }
    else
    {
    textBox1.Text = textBox1.Text;
    }
    }
