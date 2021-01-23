    public MusicPlayer(IList<string> trackFileNames)
    {
       ..
       this.soundPlayer = new SoundPlayer();
       this.timer = new Timer();
    }
    public void PlayAll()
    {
       this.PlayNext();
       timer.Tick += new EventHandler(ClockTick);
       timer.Interval = duration;
       timer.Start();
    }
    private void PlayNext()
    {
}
}
