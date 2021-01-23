        public void SetMax(int value)
        {
            if (this.ProgressBar_status.InvokeRequired)
            {
               this.BeginInvoke(new Action<int>(SetMax), value);
               return;
            }
            this.ProgressBar_status.Maximum = value;
        }
