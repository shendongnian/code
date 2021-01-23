        List<string> items = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            items.AddRange(new string[] {"Cat", "Dog", "Carrots", "Brocolli"});
            foreach (string str in items) 
            {
                listBox1.Items.Add(str); 
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string str in items) 
            {
                if (str.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBox1.Items.Add(str);
                }
            }
        }
