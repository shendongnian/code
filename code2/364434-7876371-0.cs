        public void blink()
        {
            while (true)
            {
                textBox1.Text = "|";
                Thread.Sleep(200);
                textBox1.Text = "";
                Thread.Sleep(200);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(blink));
            t1.Start();
        }
