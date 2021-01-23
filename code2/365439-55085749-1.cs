    System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    myTimer.Tick += new EventHandler(GetDuration);
    myTimer.Interval = 100;
    wplayer.controls.play();
    return;
    // Check for duration in this other routine which runs every 100 msec until 
    // Media Player tells us the duration.
    private string GetDuration()
    {
        // public variable songDuration declared elsewhere
        songDuration = wplayer.currentMedia.durationString;
        if (songDuration.Length > 0) wplayer.controls.pause();
    }
