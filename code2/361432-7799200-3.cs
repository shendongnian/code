        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(loop));
            t.Start();
        }
        private void loop()
        {
            for (int i = 0; i < 100000; i++)
            {
                textBox1.Text = i.ToString();
            }
        }
