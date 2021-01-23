        int lastDeactivateTick;
        bool lastDeactivateValid;
        protected override void OnDeactivate(EventArgs e) {
            base.OnDeactivate(e);
            lastDeactivateTick = Environment.TickCount;
            lastDeactivateValid = true;
            this.Hide();
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            if (lastDeactivateValid && Environment.TickCount - lastDeactivateTick > 1000) {
                this.Show();
                this.Activate();
            }
        }
