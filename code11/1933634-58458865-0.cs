       private void ScanpXRF()
            {
                _pXRFTimerCounter = 0;
                pXRFTimer.Enabled = true;
                pXRFTimer.Interval = 1000;
                pXRFTimer.Elapsed += new ElapsedEventHandler(pXRFTimer_Tick);
                pXRFTimer.Start();
            }
    
            private static void pXRFTimer_Tick(Object sender, EventArgs e)
            {
                _pXRFTimerCounter++;
    
                if (_pXRFTimerCounter >= 90)
                {
                    pXRFTimer.Stop();
                    // do something...               
                }
                else
                {
                    MessageBox.Show(_pXRFTimerCounter.ToString() + " seconds passed");
                }
            }
