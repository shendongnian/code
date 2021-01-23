        protected override void OnStart(string[] args)
        {
            scheduleTimer = new System.Threading.Timer(new TimerCallback(AutoTick), null, 0, 3000);
            eventLogEmail.WriteEntry("Test");
        }
        private void AutoTick(object state)
        {
            MessageBox.Show("Ticked")
        }
