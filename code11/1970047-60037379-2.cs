    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Char.IsLetterOrDigit(e.KeyChar))
        {
            var tb = (sender as TextBox);
            var text = tb.Text;
            var blocks = text.Split('-');
            var lastBlock = blocks.Last();
            if (lastBlock.Length == 6)
            {
                tb.Text += "-";
                tb.SelectionStart = tb.Text.Length;
            }
        }
    }
 
