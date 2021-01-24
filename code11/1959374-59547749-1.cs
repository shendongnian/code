          private void ChekingStateOfThreads()
        {
                while (true)
                {
                Thread.Sleep(1000);
               
                if (t.ThreadState == ThreadState.Stopped)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnpause.Enabled = btnstart.Enabled = false;
                            btnresume.Enabled = btnstop.Enabled = true;
                        }));
                    }
                    else if (t.ThreadState == ThreadState.Running)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnstart.Enabled = btnresume.Enabled = false;
                            btnpause.Enabled = btnstop.Enabled = true;
                        }));
                    }
                    else if (t.ThreadState == ThreadState.Aborted)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnstart.Enabled = true;
                            btnpause.Enabled = btnresume.Enabled = btnstop.Enabled = false;
                        }));
                    }
                    else if (t.ThreadState == ThreadState.Suspended)
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnpause.Enabled = btnstart.Enabled = false;
                            btnresume.Enabled = btnstop.Enabled = true;
                        }));
                    }
                }
        }
