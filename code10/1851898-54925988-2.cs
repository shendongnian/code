    private void PlayMenu_Load(object sender, EventArgs e)
    {
        // call our new method that starts a new thread when the form loads.
        StartANewThread();
    }
    void StartANewThread()
    {
        var task = Task.Run(() =>
        {
            /* if you're not used to threading an infinite while loop would look bad but
               it's actually okay because you're going to pause it for 100 milliseconds and 
               it's not going to hold up the rest of the CPU processes.
             */
            
            while (true)
            {
                // sleep this thread for 0.1 seconds. 
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                TimeElasped += 0.1F;
                // I would usually use begin invoke to switch back to the UI Thread and update the label
                // as you can't update UI Elements from a Non-UI thread.
                label1.BeginInvoke(new MethodInvoker(UpdateLabelOnUiThread));
            }
        });
    }
    private void UpdateLabelOnUiThread()
    {
        // We're back on the UI thread here because of the BeginInvoke. 
        // We can now update the label.
        label1.Text = $"{TimeElasped:0.0} Secs";
    }
