    public void EnableTimer()
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(EnableTimer));
                else
                    this.timer1.Enabled = true;
            }
