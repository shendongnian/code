    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (!string.IsNullOrEmpty(textBox1.Text))
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            int valueBefore = Int32.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowThousands);
            textBox1.Text = String.Format(culture, "{0:N0}", valueBefore);
            textBox1.Select(textBox1.Text.Length, 0);
        }
    }
