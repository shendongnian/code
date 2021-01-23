    private void button1_Click(object sender, EventArgs e)
    {
        if (textBox1.Text == "Andrea" || textBox1.Text == "Brittany")
        {
            Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
        }
        else
        {
            MessageBox.Show("The spelling of the name is incorrect", "Bad Spelling");
        }
    }
