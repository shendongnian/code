    private void button1_Click(object sender, EventArgs e)
    {
        if (comboBox1.Visible)
        {
            comboBox1.Visible = false;
            textBox1.Visible = true;
        }
        else
        {
            comboBox1.Visible = true;
            textBox1.Visible = false;
        }
    }
