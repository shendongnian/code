        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = String.Empty;
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
