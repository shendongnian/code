    public void Play() 
        { 
            player = new SoundPlayer(); 
            player.SoundLocation = "myfile"; 
            Timer timer = new Timer(); 
            timer.Tick += (s,e) => 
                {
                    player.Stop();
                    timer.Stop();
                };
            timer.Interval = duration; 
            player.Play();
            timer.Start(); 
        } 
