        static void MouseEnteredYourRectangleEvent(object sender, MouseEventArgs e)
        {
            Timer delayTimer = new Timer();
            delayTimer.Interval = 2000; // 2000msec = 2 seconds
            delayTimer.Tick += new ElapsedEventHandler(delayTimer_Elapsed);
        }
        static void delayTimer_Elapsed(object sender, EventArgs e)
        {
            if(MouseInRectangle())
                DoSomething();
            ((Timer)sender).Enabled = false;
        }
