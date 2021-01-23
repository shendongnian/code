    int i = 0;
    string[] songs = new string[] { "click.wav" };
    Timer timer = new Timer(){ Interval = clickSlider.Value * 1000 }; // 1000 = 1 second
    EventHandler handler = (s,e) => 
    { 
        timer.Stop(); 
        PlayNext(songs, i++); 
        if(i < songs.Length)
            timer.Start(); 
    };
    timer.Tick += handler;
    
    handler(null,null); // starts timer and plays first song.
...
    
    void PlayNext(string[] songs, int index)
    {
        using (var stream = TitleContainer.OpenStream(songs[index]))
        {
            var effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }    
    }
    
