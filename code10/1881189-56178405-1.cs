    public List<PianoSound> soundsToFadeOut = new List<PianoSound>();
    public void Play (string name)
    {
        PianoSound s = Array.Find(PianoSounds, sound => sound.name == name);  
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    soundsToFadeOut.Add(s);
    }
    
