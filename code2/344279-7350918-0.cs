    private void button11_Click(object sender, EventArgs e)
        {
           decimal sum2 = 0;
           decimal.TryParse(maskedTextBox2.Text, out sum2);
            maskedTextBox2.Text = (
                sum2 * 0.0628m +  200
                ).ToString();
        }
