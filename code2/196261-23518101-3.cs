    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab)
        {
            MessageBox.Show("The tab key was pressed while holding these modifier keys: "
                    + e.Modifiers.ToString());
        }
    }
