    private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Console.WriteLine("Enter Key:" + textBox1.Text);
                }
                else if(e.KeyCode == Keys.Down)
                {
                    Console.WriteLine("Key Down:" + textBox1.Text);
                }
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                 Console.WriteLine("Text changed:" + textBox1.Text);
            }
