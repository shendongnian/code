    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.Text.Length == 0)
            {
                listbox1.Visible = false;
                return;
            }
            foreach (String keyword in textBox1.AutoCompleteCustomSource)
            {
                if (keyword.Contains(textBox1.Text))
                {
                    listBox1.Items.Add(keyword);
                    listBox1.Visible = true;
                }
            }
        }
