         private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                int indicee = listBox1.SelectedIndex;
                label2.Text = indicee.ToString();
            }
            if (e.KeyCode == Keys.Down)
            {
                int indicee = listBox1.SelectedIndex;
                label2.Text = indicee.ToString();
            }
