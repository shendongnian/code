    private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                FileStream register = new FileStream("store.txt",
                FileMode.Append, FileAccess.Write);
                StreamWriter open = new StreamWriter(register);
                open.WriteLine(textBox1.Text);
                open.WriteLine(textBox2.Text);
                open.Close();
                register.Close();
            }
            else
                MessageBox.Show("something went wrong");
        }
