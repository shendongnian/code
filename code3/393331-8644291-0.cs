    public void PlayMusicEvent(object sender, ElapsedEventArgs e)
    {
        music.player.Stop();
        System.Timers.Timer myTimer = (System.Timers.Timer)sender;
        myTimer.Stop();
    }
