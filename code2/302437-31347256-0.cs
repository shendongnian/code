    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SupressKeyPress = true; // turn off ding
            // Perform search now.
        }
    }
