    public bool StopRequested {get; set;}
    void timer_Tick(object sender, EventArgs e)
    {
        try
        {
             timerRescan.Stop();
             ScanForIeInstances()
        }
        catch (Exception ex)
        {
             log.Warn("Exception 3", ex);
        }
        finally
        {
            if (StopRequested)
            {
                timerRescan.Start();
                StopRequested = false;
            }
        }
    }
