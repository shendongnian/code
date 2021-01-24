        private void button1_Click(object sender, EventArgs e)
        {
            var sum = 0;
            var value = 0;
            listBox1.Items.Add(textBox1.Text);
            foreach (var item in listBox1.Items)
            {
                if (!int.TryParse(item.ToString(), out value))
                    continue;
                sum = sum + value;
            }
            label1.Text = sum.ToString();
            textBox1.Text = string.Empty;
        }
