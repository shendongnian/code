        bool timerElapsed;
        public void DoWork()
        {
            timerElapsed=false;
            System.Timers.Timer timer = new System.Timers.Timer(30000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
          
            while (true)
            {
                if (timerElapsed)
                {
                    // handle 30-sec elasped error
                    break;
                }
                // continue doing work and break when done
            }
            timer.Stop();
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerElapsed = true;
        }
        
