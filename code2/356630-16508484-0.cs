        private void myTest{
            // SET SOMETHING UP
            bool bTimer_Expired = true;
            m_theTimer = new System.Timers.Timer();
            m_theTimer.Elapsed += new ElapsedEventHandler(OurTimerCallback);
            const int hrsToMs = 60 * 60 * 1000;
            m_theTimer.Interval = TestPeriodHours * hrsToMs;
            m_theTimer.Enabled = true;
            //Wait for call back to set flag that the elapsed time has expired
            while(!bTimer_Expired)Sleep(1000);
            //---->want to wait for 24 hours<------
            // RESUME TEST HERE
            VerifySomething()
         public void OurTimerCallback(object source, ElapsedEventArgs e)
         {
         bTimer_Expired=true;
         Console.WriteLine("Received a callback, the time is {0}", e.SignalTime);
         }
