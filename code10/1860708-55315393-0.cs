    bool paused = false;
    public bool Paused 
    {
        get 
        {
            return paused;
        }
    }
    public void PlayMusic()
    {
        paused = false;
        //Do other stuff to play music
    }
