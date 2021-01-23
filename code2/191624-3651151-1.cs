        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            this.BeginInvoke(new MethodInvoker(delayedClick));
        }
        private void delayedClick() {
            if (reentrancyDetected) System.Diagnostics.Debugger.Break();
            reentrancyDetected = true;
            lock (thisLock) {
                //do nothing
            }
            reentrancyDetected = false;
        }
