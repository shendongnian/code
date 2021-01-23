    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (Regex.IsMatch(textBox1.Text, "[0-9]"))
        {
            MessageBox.Show("Only letters please");
            textBox1.Text = Regex.Replace(textBox1.Text, "[0-9]", String.Empty);
        }
    }
