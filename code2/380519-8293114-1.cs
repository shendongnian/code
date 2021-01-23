        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string regex = "(([0-9a-zA-Z]){5}-){4}([0-9a-zA-Z]){5}";
            this.textBox1.BackColor = Regex.IsMatch(this.textBox1.Text, regex) && !textBox1.Text == string.Empty ?
                                System.Drawing.Color.Green :
                                System.Drawing.Color.Red;
            if (this.textBox1.Text == string.Empty)
            {
                this.textBox1.BackColor = System.Drawing.Color.White;
            }
            else
            {
                this.textBox1.ForeColor = System.Drawing.Color.White;
            }
        }
