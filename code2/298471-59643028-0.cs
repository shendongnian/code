        int count = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            if (count != 0 && count > 0)
            {
                label1.Text = count / 60 + ":" + ((count % 60) >= 10 ? (count % 60).ToString() : "0" + (count % 60));
            }
            else
            {
                label1.Text = "game over";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
