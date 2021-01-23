    private void buttonStartDepth_Click(object sender, EventArgs e)
    {
        Keypad keypad = new Keypad();
        if (keypad.ShowDialog() == DialogResult.OK)
        {
            String total = keypad.ToString();
        }
    }
