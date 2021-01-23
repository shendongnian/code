        private string oldTextboxValue = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != oldTextboxValue)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            oldTextboxValue = textBox1.Text;
            button1.Visible = false;
        }
