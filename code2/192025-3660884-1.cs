    HashSet<string> correctNames = ;// initialize the set with the names you want
    private void button1_Click(object sender, EventArgs e)
    {
        if (correctNames.Contains(textBox1.Text))
            Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
        else 
        {
           MessageBox.Show("The speling of the naem " + textBox1.Text + " was incorect", "Bad Spelling Error");
        }
    }
