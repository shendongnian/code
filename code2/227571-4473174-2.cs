        protected override void OnPause()
        {
        
            base.OnPause();
            this.timer.Stop();
            
  
        }
        protected override void OnContinue()
        {
            base.OnContinue();
            this.timer.Interval = 1;
            this.timer.Start();
        
        }
        protected override void OnStop()
        {
            base.OnStop();
            this.timer.Stop();
        }
