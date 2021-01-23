    private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("button1");
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show("button2");
                button1_Click(sender, e);
            }
