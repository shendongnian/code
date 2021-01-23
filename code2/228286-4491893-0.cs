    private void button1_Click(object sender, EventArgs e)
    {
        //textBox2.Text += Convert.ToString (textBox1.Text + "garment");
        if (textBox1.MaxLength > 0)
        {
            textBox2.Text = Convert.ToBoolean(Math.Sqrt(textBox1.MaxLength)).ToString();
        }
        else
        {
            if (textBox1.MaxLength < 32768)
            {
                textBox2.Text = Convert.ToBoolean(Math.Sqrt(textBox1.MaxLength)).ToString();
            }
        }
    }
