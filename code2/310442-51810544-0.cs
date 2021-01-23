        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timerEvent);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }
       
        private void timerEvent(object sender, EventArgs e)
        {
            DoSomeThingWithInternet();
        }
       
         private void DoSomeThingWithInternet()
        {
            if (isConnected())
            {
               // inform user that "you're connected to internet"
            }
            else
            {
                 // inform user that "you're not connected to internet"
            }
        }
 
        public static bool isConnected()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
