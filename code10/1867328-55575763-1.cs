        Timer timer = new Timer();
        timer.Interval = 100;
        timer.Elapsed += YourAmasingEvent;
        timer.Start();
        private void YourAmasingEvent(object sender, ElapsedEventArgs e)
        {
            //do something here            
            (sender as Timer).Start();
        }
