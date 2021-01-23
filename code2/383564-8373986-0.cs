    int tot = 0;
    private void tb_TextChanged(object sender, EventArgs e)
    {
        // Update sum here
        tot = 0;
        tot += Int.Parse(Textbox1.Text); // No error checking, just an example
        tot += Int.Parse(Textbox2.Text);
    }
