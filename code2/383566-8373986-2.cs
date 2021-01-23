    double tot = 0;
    private void tb_TextChanged(object sender, EventArgs e)
    {
        // Update sum here
        tot = 0;
        tot += Int.Parse(Textbox1.Text); // No error checking, just an example
        tot += Double.Parse(Textbox2.Text); // Be careful to decimal separator
        TotalTextBox.Text = tot.ToString();
    }
