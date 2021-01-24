     private void button1_Click(object sender, EventArgs e)
        {
            double s = double.Parse(textBox1.Text);
            double n = double.Parse(textBox2.Text);
            double a = double.Parse(textBox3.Text);
            double result = (s / n) * a;
            label1.Text = result.ToString();
        }
