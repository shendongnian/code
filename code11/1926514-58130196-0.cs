        public void DisplayRestaurant()
        {
            //Display restaurant here
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayRestaurant();
            timer1.Interval = 5000;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (true)//check new order
            {
                DisplayRestaurant();
            }
        }
