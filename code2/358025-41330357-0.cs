    private void updateProgressBars(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                FillDiskRatio(false);
            }));
        }
