    private void textBoxK2400_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {
            string command = textBoxK2400.Text.Split('\n').LastOrDefault();
            if (!String.IsNullOrEmpty(command) && command.StartsWith(">>"))
            {
                K2400.WriteString(command.Substring(2), true);
                textBoxK2400.Text += K2400.ReadString() + Environment.NewLine;
            }
        }
    }
