    private delegate void UpdateProgressBarCallback(int barValue);
    private void UpdateProgressBarHandler(int barValue)
    {
        if (this.progressBar1.InvokeRequired)
            this.BeginInvoke(new UpdateProgressBarCallback(this.UpdateProgressBarHandler), new object[]{ barValue });
        else
        {
            // change your bar
            this.progressBar1.Value = barValue;
            }
        }
    }
