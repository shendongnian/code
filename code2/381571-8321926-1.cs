    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", textBox1.Text))
        {
            MessageBox.Show("This textbox accepts only alphabetical characters");
            textBox1.Text.Remove(textBox1.Text.Length - 1);
        }
    }
