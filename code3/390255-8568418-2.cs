        delegate void updateProgressBarStatus(bool done);
        private void updateProgressbar1(bool done)
        {
            if (progressBar1.InvokeRequired)
            {
                updateProgressBarStatus del = new updateProgressBarStatus(updateProgressbar1);
                progressBar1.Invoke(del, new object[] { done });
            }
            else
            {
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Minimum;
                }
                progressBar1.PerformStep();
                if (done == true)
                {
                    progressBar1.Value = progressBar1.Minimum;
                }
            }
        }
