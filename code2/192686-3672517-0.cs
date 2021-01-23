    if (textBox1.Text == "Andrea")
    {     
        Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
    }
    else if (textBox1.Text == "Brittany")
    {
        Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
    }
    else if (textBox1.Text == "Eric")
    {
        Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
    }
    else
    {
        MessageBox.Show("The spelling of the name is incorrect", "Bad Spelling");
    } 
