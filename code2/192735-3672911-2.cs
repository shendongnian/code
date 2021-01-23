    private void button1_Click(object sender, EventArgs e)
    {
        switch(textBox1.Text)
        {
            case "Andrea":
                Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
                break;
            case "Brittany":
                Commission.Text = (Convert.ToDouble(textBox2.Text) / 15).ToString();
                break;
            default:
                MessageBox.Show("The spelling of the name is incorrect", "Bad Spelling");
        }
    }
