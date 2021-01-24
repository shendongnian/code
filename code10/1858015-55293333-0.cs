    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        int output;
        if (int.TryParse(textBox2.Text, out output))
        {
            bminus.Enabled = int.Parse(textBox2.Text) > 0;
        }
    }
