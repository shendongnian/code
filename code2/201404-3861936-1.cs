           private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 2000;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           using(var form1 = new Form1())
            {
                form1.Shakedetectionmouse(EventArgs.Empty);
            }
        }
