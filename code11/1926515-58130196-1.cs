        public void DisplayRestaurantOrder()
        {
            //Display restaurant order here
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayRestaurantOrder();
            timer1.Interval = 5000;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (true)//check new order
            {
                DisplayRestaurantOrder();
            }
        }
