        int interval = 10 * 24 * 60 * 60 * 1000; // Time interval for 10 days 
        int counter = 0;
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter++;
            if (counter == 9) 
            {
                //do your task for 3 months
                //since counter increments 9 times at interval of 10 days
                //so 9*10=90 days i.e. nearly equal to 3 months
                counter = 0;
            }
        }
