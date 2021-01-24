    private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "test")
            {
                label1.Show();
                label2.Hide();
            }
            else
            {
                label1.Hide();
                label2.Show();
            }
        }
