    private void button1_Click(object sender, EventArgs e)
        {
            int s = int.Parse(textBox1.Text);
            int n = int.Parse(textBox2.Text);
            int a = int.Parse(textBox3.Text);
            int result = (s / n) * a;
            label1.Text = result.ToString();
        }
