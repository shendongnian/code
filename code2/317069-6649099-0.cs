          private int i = 0;
        private int[] a = new int[2];
        private void button1_Click(object sender, EventArgs e)
        {
            int b;
            if(Int32.TryParse(textBox1.Text, out b))
            {
                a[i] = b;
                i++;
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show(@"Incorrect number");
            }
        }
        private void resultbutton2_Click(object sender, EventArgs e)
        {
            int sum = a[0] + a[1];
            MessageBox.Show("Sum: " + sum);
        }
    }
